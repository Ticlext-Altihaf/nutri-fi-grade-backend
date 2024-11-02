using Microsoft.AspNetCore.Mvc;
using Server.AI;
using Server.AI.Methods;

namespace Server.Controllers;
[ApiController]
[Route("[controller]/[action]")]
public class DebugController : ControllerBase
{
    private readonly MethodChainOfThought _chainOfThought;
    private readonly CommonMethods _commonMethods;
    private readonly PromptTechniques _promptTechniques;

    public DebugController(MethodChainOfThought chainOfThought, CommonMethods commonMethods, PromptTechniques promptTechniques)
    {
        _chainOfThought = chainOfThought;
        _commonMethods = commonMethods;
        _promptTechniques = promptTechniques;
    }


    [HttpPost(Name = "Observation")]
    public async Task<IActionResult> Observation(IFormFile? image)
    {
        if (image == null)
        {
            return BadRequest("No image provided.");
        }

        string dataUri = await CommonMethods.ConvertIFormFileToDataUri(image);
        var result = await _chainOfThought.Observation(dataUri);
        return Ok(result);
    }

    [HttpPost(Name = "ObservationWithConsensus")]
    public async Task<IActionResult> ObservationWithConsensus(IFormFile? image)
    {
        if (image == null)
        {
            return BadRequest("No image provided.");
        }

        string dataUri = await CommonMethods.ConvertIFormFileToDataUri(image);
        var result = await _commonMethods.ParallelExecution(() => _chainOfThought.Observation(dataUri), 5);
        // filter
        List<string> nonNullResults = result.OfType<string>().ToList();

        var consensus = await _promptTechniques.FindConsensus(nonNullResults);
        return Ok(consensus);
    }
}