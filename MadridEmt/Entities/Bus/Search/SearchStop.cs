using System.Text.Json.Serialization;

namespace MadridEmt.Entities.Bus.Search;

public class SearchStop
{
    [JsonPropertyName("stopId")]
    public int StopId { get; set; }
    [JsonPropertyName("geometry")]
    public SpatialPoint Location { get; set; }
    [JsonPropertyName("stopName")]
    public string Name { get; set; }
    [JsonPropertyName("address")]
    public string PostalAddress { get; set; }
    [JsonPropertyName("metersToPoint")]
    public int DistanceToBusStop { get; set; }
    [JsonPropertyName("lines")]
    public List<SearchBusLine> BusLines { get; set; }
}

