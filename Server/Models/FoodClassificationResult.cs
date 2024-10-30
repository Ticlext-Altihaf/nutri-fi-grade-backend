using System.Text.Json.Serialization;

namespace Server.Models;

public class FoodClassificationResult
{
    public enum NOVA
    {
        UNDEFINED,
        ONE,
        TWO,
        THREE,
        FOUR
    }
    public enum NutriScore
    {
        UNDEFINED,
        A,
        B,
        C,
        D,
        E
    }
    public string? Observation { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public NOVA? NovaClassification { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public NutriScore? NutriGrade { get; set; }

}