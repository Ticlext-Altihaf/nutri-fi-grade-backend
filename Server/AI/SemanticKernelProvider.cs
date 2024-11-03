using Microsoft.Extensions.Options;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

#pragma warning disable SKEXP0050

#pragma warning disable SKEXP0070
#pragma warning disable SKEXP0010
namespace Server.AI;

public class SemanticKernelProvider
{

    private readonly IOptions<AppConfiguration> _options;
    private readonly ILogger<SemanticKernelProvider> _logger;

    private Kernel? Kernel { get; set; }
    private Kernel? FastKernel { get; set; } // sacrifice accuracy for speed
    public SemanticKernelProvider(IOptions<AppConfiguration> options, ILogger<SemanticKernelProvider> logger)
    {
        _options = options;
        _logger = logger;
    }


    public Kernel GetKernel()
    {
        if (this.Kernel != null)
        {
            return this.Kernel;
        }


        var res = ChangeChatModel(null);
        if (res is null)
        {
            throw new Exception("No chat model found");
        }

        return res;
    }

    /// <summary>
    /// Initialize the kernel and load plugins.
    /// </summary>
    /// <returns>A kernel instance</returns>
    private IKernelBuilder? CreateBuilder(string? model = null)
    {
        var builder = Kernel.CreateBuilder();
        var selectedModel = _options.Value.GetSelectedModel(model);
        if (selectedModel is null)
        {
            return null;
        }

        var endpoint = selectedModel.Endpoint;


        _logger.LogInformation($"Selected model: {selectedModel.GetDisplayName()}");
        _logger.LogInformation($"Endpoint: {endpoint}");


        if (selectedModel.Type == "AzureAIInference")
        {
            builder.AddAzureAIInferenceChatCompletion(
                modelId: selectedModel.GetDisplayName(),
                apiKey: selectedModel.Key,
                endpoint: new Uri(endpoint)
            );
        }else if(selectedModel.Type == "AzureOpenAI")
        {
            builder.AddAzureOpenAIChatCompletion(
                deploymentName: selectedModel.DeploymentName,
                apiKey: selectedModel.Key,
                endpoint: endpoint
            );
        }
        else
        {
            builder.AddOpenAIChatCompletion(
                modelId: selectedModel.GetDisplayName(),
                apiKey: selectedModel.Key,
                endpoint: new Uri(endpoint)
            );
        }

        return builder;
    }


    public Kernel? ChangeChatModel(string? model = null)
    {
        var builder = CreateBuilder(model);
        if(builder is null)
        {
            return null;
        }
        this.Kernel = builder.Build();



        return this.Kernel;
    }

    public IChatCompletionService GetChatCompletionService()
    {
        var kernel = GetKernel();
        return kernel.GetRequiredService<IChatCompletionService>();
    }

    public Kernel GetFastKernel()
    {
        if (this.FastKernel != null)
        {
            return this.FastKernel;
        }

        var res = ChangeChatModel("gpt-4o-mini");
        if (res is null)
        {
            throw new Exception("No fast chat model found");
        }
        return res;
    }

    public IChatCompletionService GetFastChatCompletionService()
    {
        var kernel = GetFastKernel();
        return kernel.GetRequiredService<IChatCompletionService>();
    }
}