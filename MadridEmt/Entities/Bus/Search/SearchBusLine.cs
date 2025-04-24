using System.Text.Json.Serialization;

namespace MadridEmt.Entities.Bus.Search;

public class SearchBusLine
{
    [JsonPropertyName("line")]
    public string Line { get; set; }
    [JsonPropertyName("label")]
    public string Name { get; set; }
    [JsonPropertyName("nameA")]
    public string HeaderNameA { get; set; }
    [JsonPropertyName("nameB")]
    public string HeaderNameB { get; set; }
    [JsonPropertyName("metersFromHeader")]
    public int DistanceFromHeader { get; set; }
    [JsonPropertyName("to")]
    public string ToHeader { get; set; }
}