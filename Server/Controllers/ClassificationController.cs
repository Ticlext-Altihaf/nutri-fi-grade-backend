using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Server.AI;
using Server.AI.Methods;
using Server.Models;
using Server.Services;

namespace Server.Controllers;
#pragma warning disable SKEXP0010
[ApiController]
[Route("[controller]")]
public class ClassificationController : ControllerBase
{


    private readonly MethodChainOfThought _chainOfThought;
    private readonly SemanticKernelProvider _semanticKernelProvider;
    private readonly IUserLanguageService _userLanguageService;

    public ClassificationController(MethodChainOfThought chainOfThought, SemanticKernelProvider semanticKernelProvider, IUserLanguageService userLanguageService)
    {
        _chainOfThought = chainOfThought;
        _semanticKernelProvider = semanticKernelProvider;
        _userLanguageService = userLanguageService;
    }

    private async Task<FoodClassificationResult?> ToStructuredOutput(string analysis)
    {
        var kernel = _semanticKernelProvider.GetKernel();
        var language = _userLanguageService.GetUserLanguage();
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("What is the NOVA and Nutri-Score classification of this food? if NOVA is high it can be difficult to guess Nutri-Score.");
        stringBuilder.AppendLine("Give observation in " + language + " language.");


        var tasks = new List<Task<FoodClassificationResult?>>();
        var random = new Random();
        for (var i = 0; i < 5; i++)
        {
            tasks.Add(Task.Run(async () =>
            {
                var executionSettings = new OpenAIPromptExecutionSettings
                {
                    ResponseFormat = typeof(FoodClassificationResult),
                    ChatSystemPrompt = stringBuilder.ToString(),
                    Temperature = 0.65,
                    Seed = random.NextInt64(),
                };

                var result = await kernel.InvokePromptAsync(analysis, new KernelArguments(executionSettings));
                var options = new JsonSerializerOptions
                {
                    Converters = { new JsonStringEnumConverter() }
                };
                var json = result.ToString();
                return JsonSerializer.Deserialize<FoodClassificationResult>(json, options);
            }));
        }

        var results = await Task.WhenAll(tasks);

        // Return the last non-null result, or null if all are null
        return await FindConsensus(results);
    }

    private async Task<T?> FindConsensus<T>(IEnumerable<T> results)
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


    [HttpPost(Name = "UploadImage")]
    public async Task<IActionResult> UploadImage(IFormFile? image)
    {
        if (image == null || image.Length == 0)
        {
            return BadRequest("No image uploaded.");
        }

        var observation = await _chainOfThought.Analyze(image);
        if(observation == null) return BadRequest("No observation found.");
        var structure = await ToStructuredOutput(observation);
        if(structure == null) return BadRequest("No structured output found.");

        return Ok(structure);

    }

}