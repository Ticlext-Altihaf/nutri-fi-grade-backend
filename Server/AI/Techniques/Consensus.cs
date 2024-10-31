using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;

namespace Server.AI.Techniques;
#pragma warning disable SKEXP0010
public class Consensus
{

    private readonly SemanticKernelProvider _semanticKernelProvider;

    public Consensus(SemanticKernelProvider semanticKernelProvider)
    {
        _semanticKernelProvider = semanticKernelProvider;
    }

    public async Task<T?> FindConsensus<T>(IEnumerable<T> results)
    {
        var kernel = _semanticKernelProvider.GetKernel();
        var executionSettings = new OpenAIPromptExecutionSettings
        {
            ResponseFormat = typeof(T),
            ChatSystemPrompt = "Find the consensus of the following results and get rid of faulty reasoning.",
            Temperature = 0,
        };


        var result = await kernel.InvokePromptAsync(JsonSerializer.Serialize(results), new KernelArguments(executionSettings));
        var options = new JsonSerializerOptions
        {
            Converters = { new JsonStringEnumConverter() }
        };
        var json = result.ToString();
        return JsonSerializer.Deserialize<T>(json, options);
    }
}