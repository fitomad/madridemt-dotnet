using System.Text.Json.Serialization;

namespace MadridEmt.Entities.Bus.Arrivals;

public record ArrivalDetails
{
    [JsonPropertyName("Arrive")]
    public List<BusArrival> BusArrivals { get; set; }

    [JsonPropertyName("StopInfo")] 
    public List<ArrivalStop> StopInfo { get; set; }

    [JsonPropertyName("ExtraInfo")]
    public List<object> ExtraInfo { get; set;  }

    [JsonPropertyName("Incident")]
    public Dictionary<string, object> Incident { get; set; }
}
