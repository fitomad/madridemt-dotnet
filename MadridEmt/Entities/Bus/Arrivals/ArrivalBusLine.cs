using System.Text.Json.Serialization;

namespace MadridEmt.Entities.Bus.Arrivals;

public record ArrivalBusLine
{
    [JsonPropertyName("label")]
    public string Name { get; set; }
    [JsonPropertyName("line")]
    public string Line { get; set; }
    [JsonPropertyName("nameA")]
    public string LineHeaderA { get; set; }
    [JsonPropertyName("nameB")]
    public string LineHeaderB { get; set; }
    [JsonPropertyName("metersFromHeader")]
    public int DistanceFromHeader { get; set; }
    [JsonPropertyName("to")]
    public string ToHeader { get; set; }
    [JsonPropertyName("color")]
    public string HexBackgroundColor { get; set; }
    [JsonPropertyName("forecolor")]
    public string? HexForegroundColor { get; set; } // Nullable to handle cases where it's not present
}