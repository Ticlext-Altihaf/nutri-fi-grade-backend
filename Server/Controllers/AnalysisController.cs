using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
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
[Route("[controller]/[action]")]
public class AnalysisController : ControllerBase
{


    private readonly MethodChainOfThought _chainOfThought;
    private readonly SemanticKernelProvider _semanticKernelProvider;
    private readonly IUserLanguageService _userLanguageService;
    private readonly PromptTechniques _promptTechniques;
    private readonly IMemoryCache _cache;

    public AnalysisController(MethodChainOfThought chainOfThought, SemanticKernelProvider semanticKernelProvider, IUserLanguageService userLanguageService, PromptTechniques promptTechniques, IMemoryCache cache)
    {
        _chainOfThought = chainOfThought;
        _semanticKernelProvider = semanticKernelProvider;
        _userLanguageService = userLanguageService;
        _promptTechniques = promptTechniques;
        _cache = cache;
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
        return await _promptTechniques.FindConsensus(results);
    }


    [HttpPost(Name = "Method3")]
    public async Task<IActionResult> Method3(IFormFile? image)
    {
        if (image == null || image.Length == 0)
        {
            return BadRequest("No image uploaded.");
        }
        // Compute hash of the file
        string fileHash;
        await using (var stream = image.OpenReadStream())
        {
            using (var sha256 = SHA256.Create())
            {
                var hashBytes = await sha256.ComputeHashAsync(stream);
                fileHash = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
            }
        }

        // Check if the result is already cached
        if (_cache.TryGetValue(fileHash, out var cachedResult))
        {
            return Ok(cachedResult);
        }

        var observation = await _chainOfThought.Analyze(image);
        if(observation == null) return BadRequest("No observation found.");
        var structure = await ToStructuredOutput(observation);
        if(structure == null) return BadRequest("No structured output found.");

        // Cache the result
        _cache.Set(fileHash, structure, TimeSpan.FromHours(2));

        return Ok(structure);

    }

}