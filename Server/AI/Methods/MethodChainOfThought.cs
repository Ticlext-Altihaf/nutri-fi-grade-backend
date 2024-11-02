using System.Text;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;

namespace Server.AI.Methods;

// Sherlock Holmes moment
public class MethodChainOfThought
{
    private readonly SemanticKernelProvider _semanticKernelProvider;
    private readonly CommonMethods _commonMethods;
    private readonly Random _random = new Random();

    public MethodChainOfThought(SemanticKernelProvider semanticKernelProvider, CommonMethods commonMethods)
    {
        _semanticKernelProvider = semanticKernelProvider;
        _commonMethods = commonMethods;
    }

    private static async Task<string> ConvertIFormFileToDataUri(IFormFile file)
    {
        if (file == null || file.Length == 0)
            throw new ArgumentException("File is empty or null.");

        // Step 1: Read the file into a byte array
        using var memoryStream = new MemoryStream();
        await file.CopyToAsync(memoryStream);
        var fileBytes = memoryStream.ToArray();

        // Step 2: Encode the byte array in Base64
        var base64String = Convert.ToBase64String(fileBytes);

        // Step 3: Get the MIME type
        var mimeType = file.ContentType;

        // Step 4: Format the Data URI
        var dataUri = $"data:{mimeType};base64,{base64String}";

        return dataUri;
    }
    public  async Task<string?> Observation(string dataUri)
    {
        var chatCompletionService = _semanticKernelProvider.GetChatCompletionService();

        string systemPrompt = "Describe the foods one by one in the image if possible.";
        string userInput = "Create observation for this image";
        // Select an image URL to send

        // Add system message
        var chatHistory = new ChatHistory(systemPrompt);

        chatHistory.AddUserMessage([
            new TextContent(userInput),
            new ImageContent(dataUri)
        ]);

        var executionSettings = new OpenAIPromptExecutionSettings
        {
            Temperature = 0.65,
            Seed = _random.NextInt64(),
        };

        var reply = await chatCompletionService.GetChatMessageContentAsync(chatHistory, executionSettings);

        return reply.Content;
    }


    public  async Task<string?> ClassifyNova(string description)
    {
        // Use a model or logic to classify the food description into NOVA categories
        var chatCompletionService = _semanticKernelProvider.GetChatCompletionService();
        string systemPrompt = "Classify the following food description into NOVA categories, think it step-by-step.";
        string userInput = $"Classify this description: {description}";

        var chatHistory = new ChatHistory(systemPrompt);
        chatHistory.AddUserMessage([new TextContent(userInput)]);

        var reply = await chatCompletionService.GetChatMessageContentAsync(chatHistory);

        return reply.Content;
    }

    public  async Task<string?> EvaluateNutriGrade(string description)
    {
        // Use a model or logic to evaluate the Nutri-Grade of the food description
        var chatCompletionService = _semanticKernelProvider.GetChatCompletionService();
        string systemPrompt = "Evaluate the Nutri-Grade for the following food description, think it step-by-step.";
        string userInput = $"Evaluate Nutri-Grade for this description: {description}";

        var chatHistory = new ChatHistory(systemPrompt);
        chatHistory.AddUserMessage([new TextContent(userInput)]);

        var reply = await chatCompletionService.GetChatMessageContentAsync(chatHistory);

        return reply.Content;
    }


    public async Task<string?> Analyze(IFormFile image)
    {
        var observation = await _commonMethods.Observation(image);
        if(observation == null)
        {
            return null;
        }
        var novaClassificationTask = ClassifyNova(observation);
        var nutriGradeTask = EvaluateNutriGrade(observation);

        await Task.WhenAll(novaClassificationTask, nutriGradeTask);

        var novaClassification = await novaClassificationTask;
        var nutriGrade = await nutriGradeTask;
        var sb = new StringBuilder();
        sb.AppendLine("Observation:");
        sb.AppendLine(observation);
        sb.AppendLine();
        sb.AppendLine("NOVA Classification:");
        sb.AppendLine(novaClassification);
        sb.AppendLine();
        sb.AppendLine("NutriGrade:");
        sb.AppendLine(nutriGrade);
        return sb.ToString();
    }
}