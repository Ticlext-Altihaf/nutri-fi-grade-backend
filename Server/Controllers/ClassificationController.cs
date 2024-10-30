using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
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

    private async Task<FoodClassificationResult?> ToStructuredOutput(string analysis)
    {
        var kernel = ModelConfig.GetKernel();
        // Specify response format by setting Type object in prompt execution settings.
        var executionSettings = new OpenAIPromptExecutionSettings
        {
            ResponseFormat = typeof(FoodClassificationResult)
        };
        var result = await kernel.InvokePromptAsync(analysis, new KernelArguments(executionSettings));
        var resultData = JsonSerializer.Deserialize<FoodClassificationResult>(result.ToString());
        return resultData;
    }

    [HttpPost(Name = "UploadImage")]
    public async Task<IActionResult> UploadImage(IFormFile? image)
    {
        if (image == null || image.Length == 0)
        {
            return BadRequest("No image uploaded.");
        }

        var observation = await ChainOfThought.Analyze(image);
        if(observation == null) return BadRequest("No observation found.");
        var structure = await ToStructuredOutput(observation);
        if(structure == null) return BadRequest("No structured output found.");
        return Ok(ToStructuredOutput(observation));

    }

}