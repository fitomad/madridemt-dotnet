using System.Text.Json.Serialization;

namespace MadridEmt.Entities;

public record ApiRateCounter
{
    [JsonPropertyName("current")]
    public int CurrentRequestsCount { get; set; }
    [JsonPropertyName("dailyUse")]
    public int DailyRequestLimit { get; set; }
    [JsonPropertyName("owner")]
    public int Owner { get; set; }
    [JsonPropertyName("licenceUse")]
    public string License { get; set; }

    public int RemainingRequests => DailyRequestLimit - CurrentRequestsCount;
}