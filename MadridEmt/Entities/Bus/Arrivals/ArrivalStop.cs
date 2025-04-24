using System.Text.Json.Serialization;

namespace MadridEmt.Entities.Bus.Arrivals;

public class ArrivalStop
{
    [JsonPropertyName("lines")]
    public ArrivalBusLine[] BusLines { get; set; }
    [JsonPropertyName("stopId")]
    public string StopId { get; set; }
    [JsonPropertyName("stopName")]
    public string Name { get; set; }
    [JsonPropertyName("geometry")]
    public SpatialPoint Location { get; set; }
    [JsonPropertyName("Direction")]
    public string PostalAddress { get; set; }
}
