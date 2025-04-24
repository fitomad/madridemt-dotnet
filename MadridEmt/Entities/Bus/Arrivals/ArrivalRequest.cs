using System.Text.Json.Serialization;

namespace MadridEmt.Entities.Bus.Arrivals;

public struct ArrivalRequest
{
    [JsonPropertyName("cultureInfo")]
    public string Culture { get; init; }
    [JsonPropertyName("Text_StopRequired_YN")]
    public string RequestStopName { get; init; }
    [JsonPropertyName("Text_EstimationsRequired_YN")]
    public string RequestEstimations { get; init; }
    [JsonPropertyName("Text_IncidencesRequired_YN")]
    public string RequestIncidents { get; init; }
    [JsonPropertyName("DateTime_Referenced_Incidencies_YYYYMMDD")]
    public string IncidentsDay { get; init; }

    public static ArrivalRequest Default = new ArrivalRequest
    {
        Culture = "ES",
        RequestStopName = "Y",
        RequestEstimations = "Y",
        RequestIncidents = "Y",
        IncidentsDay = DateTime.Now.ToString("YYYYMMdd")
    };
    
    public static ArrivalRequest OnlyArrivals = new ArrivalRequest
    {
        Culture = "ES",
        RequestStopName = "N",
        RequestEstimations = "Y",
        RequestIncidents = "N",
        IncidentsDay = DateTime.Now.ToString("YYYYMMdd")
    };
}