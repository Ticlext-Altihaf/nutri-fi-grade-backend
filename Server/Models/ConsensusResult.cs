namespace Server.Models;

public class ConsensusResult : IReasoningResult
{
    public string? Reasoning { get; set; }
    public string? Consensus { get; set; }
}