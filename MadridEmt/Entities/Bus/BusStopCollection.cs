using System.Text.Json.Serialization;

namespace MadridEmt.Entities.Bus;

public record BusStopCollection
{
    [JsonPropertyName("stops")]
    public BusStop[] Stops { get; init; }
}