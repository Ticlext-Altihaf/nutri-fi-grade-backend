using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

namespace Server.AI;
public class ModelConfig
{
    public string? DisplayName { get; set; }
    public string Endpoint { get; set; }
    public string Key { get; set; }
    public uint ContextWindow { get; set; } = 2048;
    public string Type { get; set; } = "Other";
    public uint MaxInput { get; set; } = 4096;
    public bool IsVisionReady { get; set; } = false;

    public string ModelName => GetDisplayName();


    public string GetDisplayName()
    {
        if (DisplayName != null)
        {
            return DisplayName;
        }

        // https://Llama-3-2-11B-Vision-Instruct-xe.eastus.models.ai.azure.com => Llama-3-2-11B-Vision-Instruct-xe
        var name = Endpoint.Split(".")[0];
        name = name.Replace("https://", "");
        name = name.Replace("http://", "");
        return name;
    }


}