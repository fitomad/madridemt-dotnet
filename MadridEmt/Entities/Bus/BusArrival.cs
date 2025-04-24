using System.Text.Json.Serialization;

namespace MadridEmt.Entities.Bus;

public record BusArrival
{
    [JsonPropertyName("line")]
    public string Line { get; set; }
    [JsonPropertyName("stop")]
    public string StopId { get; set; }
    [JsonPropertyName("isHead")]
    public string IsLineHeader { get; set; }
    [JsonPropertyName("destination")]
    public string Destination { get; set; }
    [JsonPropertyName("deviation")]
    public int Deviation { get; set; }
    [JsonPropertyName("bus")]
    public int VehicleId { get; set; }
    [JsonPropertyName("geometry")]
    public SpatialPoint Geometry { get; set; }
    [JsonPropertyName("estimateArrive")]
    public int EstimatedArrivalTime { get; set; }
    [JsonPropertyName("DistanceBus")]
    public int BusDistanceToStop { get; set; }
    [JsonPropertyName("positionTypeBus")]
    public string PositionTypeBus { get; set; }
}