using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;

namespace Server.AI;

#pragma warning disable SKEXP0010
public class PromptTechniques
{
    private readonly SemanticKernelProvider _semanticKernelProvider;
    private readonly JsonSerializerOptions options = new JsonSerializerOptions
    {
        Converters = { new JsonStringEnumConverter() }
    };

    public PromptTechniques(SemanticKernelProvider semanticKernelProvider)
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

    public async Task<List<string>> MultiResponsePrompt(string prompt, int howMany)
    {
        var kernel = _semanticKernelProvider.GetKernel();
        var tasks = new List<Task<string>>();
        var executionSettings = new OpenAIPromptExecutionSettings
        {

        };

        for (var i = 0; i < howMany; i++)
        {
            tasks.Add(Task.Run(async () =>
            {
                var result = await kernel.InvokePromptAsync(prompt, new KernelArguments(executionSettings));
                return result.ToString();
            }));
        }

        var results = await Task.WhenAll(tasks);
        return results.ToList();
    }
    public async Task<List<T?>> MultiResponsePrompt<T>(string prompt, int howMany)
    {
        var kernel = _semanticKernelProvider.GetKernel();
        var tasks = new List<Task<T?>>();
        var executionSettings = new OpenAIPromptExecutionSettings
        {
            ResponseFormat = typeof(T)
        };

        for (var i = 0; i < howMany; i++)
        {
            tasks.Add(Task.Run(async () =>
            {
                var result = await kernel.InvokePromptAsync(prompt, new KernelArguments(executionSettings));
                var json = result.ToString();
                return JsonSerializer.Deserialize<T>(json, options);
            }));
        }

        var results = await Task.WhenAll(tasks);
        return results.ToList();
    }

    public async Task<string> FindConsensus(string prompt)
    {
        var howMany = 5;
        var list =  await MultiResponsePrompt<InternalConsensus>(prompt, howMany);
        // filter out nulls
        list = list.Where(x => x != null).ToList();

        var result = await FindConsensus(list);
        if(result == null)
        {
            return "No consensus found.";
        }

        return result.Result;



    }

    private class InternalConsensus
    {
        public string Result;
        public string Reasoning;
    }
}