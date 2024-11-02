using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

namespace Server.AI.Methods;

public class CommonMethods
{
    private readonly SemanticKernelProvider _semanticKernelProvider;

    public CommonMethods(SemanticKernelProvider semanticKernelProvider)
    {
        _semanticKernelProvider = semanticKernelProvider;
    }
    public static async Task<string> ConvertIFormFileToDataUri(IFormFile file)
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
    public async Task<string?> Observation(IFormFile image, string systemPrompt = "Describe the foods one by one in the image if possible.")
    {
        var chatCompletionService = _semanticKernelProvider.GetChatCompletionService();

        string userInput = "Create observation for this image";
        // Select an image URL to send
        string dataUri = await ConvertIFormFileToDataUri(image);

        // Add system message
        var chatHistory = new ChatHistory(systemPrompt);

        chatHistory.AddUserMessage([
            new TextContent(userInput),
            new ImageContent(dataUri)
        ]);

        var reply = await chatCompletionService.GetChatMessageContentAsync(chatHistory);

        return reply.Content;
    }

    public static async Task<List<T>> ParallelExecution<T>(Func<Task<T>> task, int size)
    {
        var tasks = new List<Task<T>>();
        for (var i = 0; i < size; i++)
        {
            tasks.Add(task());
        }

        var results = await Task.WhenAll(tasks);
        return results.ToList();
    }
}