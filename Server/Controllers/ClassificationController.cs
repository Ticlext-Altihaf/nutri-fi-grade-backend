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

namespace Server.Controllers;
#pragma warning disable SKEXP0010
[ApiController]
[Route("[controller]")]
public class ClassificationController : ControllerBase
{


    private readonly MethodChainOfThought _chainOfThought;
    private readonly SemanticKernelProvider _semanticKernelProvider;

    public ClassificationController(MethodChainOfThought chainOfThought, SemanticKernelProvider semanticKernelProvider)
    {
        _chainOfThought = chainOfThought;
        _semanticKernelProvider = semanticKernelProvider;
    }

    private async Task<FoodClassificationResult?> ToStructuredOutput(string analysis)
    {
        var kernel = _semanticKernelProvider.GetKernel();
        // Specify response format by setting Type object in prompt execution settings.
        var executionSettings = new OpenAIPromptExecutionSettings
        {
            ResponseFormat = typeof(FoodClassificationResult),
            ChatSystemPrompt = "What is the NOVA and Nutri-Score classification of this food? if NOVA is high it can be difficult to guess Nutri-Score.",
        };
        var result = await kernel.InvokePromptAsync(analysis, new KernelArguments(executionSettings));
        var options = new JsonSerializerOptions
        {
            Converters = { new JsonStringEnumConverter() }
        };
        var resultData = JsonSerializer.Deserialize<FoodClassificationResult>(result.ToString(), options);
        return resultData;
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