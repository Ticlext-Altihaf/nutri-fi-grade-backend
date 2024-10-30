using Server.AI;

namespace Server;

public class AppConfiguration
{
    public static string SectionName = "";

    public ModelConfig[] Models { get; set; }


    public string? SelectedModel { get; set; }

    public static ModelConfig? GetSelectedModel(ModelConfig[] Models, string? SelectedModel = null)
    {
        foreach (var model in Models)
        {
            if (model.Key == SelectedModel || model.Endpoint == SelectedModel ||
                model.GetDisplayName() == SelectedModel || SelectedModel == null)
            {
                return model;
            }
        }

        return null;
    }

    public ModelConfig? GetSelectedModel()
    {
        return GetSelectedModel(Models, SelectedModel);
    }

    public ModelConfig? GetSelectedModel(string? SelectedModel)
    {
        return GetSelectedModel(Models, SelectedModel);
    }
}