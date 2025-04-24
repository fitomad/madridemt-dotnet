using System.Text.Json.Serialization;

namespace MadridEmt.Entities.Bus;

public record BusLine
{
    [JsonPropertyName("line")]
    public string Line { get; init; }
    [JsonPropertyName("label")] 
    public string Name { get; init; }
    [JsonPropertyName("direction")]
    public string Direction { get; init; }
    [JsonPropertyName("maxFreq")]
    public int MaximunFrequency { get; init; }
    [JsonPropertyName("minFreq")]
    public int MinimunFrequency { get; init; }
    [JsonPropertyName("headerA")]
    public string LineHeaderA { get; init; }
    [JsonPropertyName("headerB")]
    public string LineHeaderB { get; init; }
    [JsonPropertyName("startTime")]
    public string StartTime { get; init; }
    [JsonPropertyName("stopTime")]
    public string EndTime { get; init; }
    [JsonPropertyName("dayType")]
    public string DayType { get; init; }
}