using System.Text.Json.Serialization;

namespace MadridEmt.Entities.Bus;

public record BusStop
{
    [JsonPropertyName("stop")]
    public int StopId { get; init; }
    [JsonPropertyName("name")]
    public string Name { get; init; }
    [JsonPropertyName("postalAddress")]
    public string PostalAddress { get; init; }
    [JsonPropertyName("geometry")]
    public SpatialPoint Location { get; init; }
    [JsonPropertyName("dataLine")]
    public BusLine[] Lines { get; init; }
}