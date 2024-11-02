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
        string systemPrompt = "Group 1. Unprocessed or minimally processed foods\nUnprocessed (or natural) foods are edible parts of plants (seeds, fruits, leaves, stems, roots) or of animals (muscle, offal, eggs, milk), and also fungi, algae and water, after separation from nature.\n\nMinimally processed foods are natural foods altered by processes that include removal of inedible or unwanted parts, and drying, crushing, grinding, fractioning, filtering, roasting, boiling, non-alcoholic fermentation, pasteurization, refrigeration, chilling, freezing, placing in containers and vacuum-packaging. These processes are designed to preserve natural foods, to make them suitable for storage, or to make them safe or edible or more pleasant to consume. Many unprocessed or minimally processed foods are prepared and cooked at home or in restaurant kitchens in combination with processed culinary ingredients as dishes or meals.\n\nGroup 2. Processed culinary ingredients\nProcessed culinary ingredients, such as oils, butter, sugar and salt, are substances derived from Group 1 foods or from nature by processes that include pressing, refining, grinding, milling and drying. The purpose of such processes is to make durable products that are suitable for use in home and restaurant kitchens to prepare, season and cook Group 1 foods and to make with them varied and enjoyable hand-made dishes and meals, such as stews, soups and broths, salads, breads, preserves, drinks and desserts. They are not meant to be consumed by themselves, and are normally used in combination with Group 1 foods to make freshly prepared drinks, dishes and meals.\n\nGroup 3. Processed foods\nProcessed foods, such as bottled vegetables, canned fish, fruits in syrup, cheeses and freshly made breads, are made essentially by adding salt, oil, sugar or other substances from Group 2 to Group 1 foods.\n\nProcesses include various preservation or cooking methods, and, in the case of breads and cheese, non-alcoholic fermentation. Most processed foods have two or three ingredients, and are recognizable as modified versions of Group 1 foods. They are edible by themselves or, more usually, in combination with other foods. The purpose of processing here is to increase the durability of Group 1 foods, or to modify or enhance their sensory qualities.\n\nGroup 4. Ultra-processed foods\nUltra-processed foods, such as soft drinks, sweet or savoury packaged snacks, reconstituted meat products and pre-prepared frozen dishes, are not modified foods but formulations made mostly or entirely from substances derived from foods and additives, with little if any intact Group 1 food.\n\nIngredients of these formulations usually include those also used in processed foods, such as sugars, oils, fats or salt. But ultra-processed products also include other sources of energy and nutrients not normally used in culinary preparations. Some of these are directly extracted from foods, such as casein, lactose, whey and gluten.\n\nMany are derived from further processing of food constituents, such as hydrogenated or interesterified oils, hydrolysed proteins, soya protein isolate, maltodextrin, invert sugar and high-fructose corn syrup.\n\nAdditives in ultra-processed foods include some also used in processed foods, such as preservatives, antioxidants and stabilizers. Classes of additives found only in ultra-processed products include those used to imitate or enhance the sensory qualities of foods or to disguise unpalatable aspects of the final product. These additives include dyes and other colours, colour stabilizers; flavours, flavour enhancers, non-sugar sweeteners; and processing aids such as carbonating, firming, bulking and anti-bulking, de-foaming, anti-caking and glazing agents, emulsifiers, sequestrants and humectants.\n\nA multitude of sequences of processes is used to combine the usually many ingredients and to create the final product (hence 'ultra-processed'). The processes include several with no domestic equivalents, such as hydrogenation and hydrolysation, extrusion and moulding, and pre-processing for frying.\n Classify the following food description into NOVA categories, think it step-by-step.";
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