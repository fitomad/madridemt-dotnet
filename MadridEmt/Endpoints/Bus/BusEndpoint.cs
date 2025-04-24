using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net;
using System.Net.Http.Json;

using MadridEmt.Entities;
using MadridEmt.Entities.Bus;
using MadridEmt.Entities.Bus.Arrivals;
using MadridEmt.Entities.Bus.Search;

namespace MadridEmt.Endpoints.Bus;

public sealed class BusEndpoint: IBusEndpoint
{
    private readonly JsonSerializerOptions _serializerOptions;
    private readonly HttpClient _httpClient;
    private readonly string _accessToken;
    
    internal BusEndpoint(HttpClient httpClient, string accessToken)
    {
        _httpClient = httpClient;
        _accessToken = accessToken;
        
        _serializerOptions = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
    }

    public async Task<BusStop> StopDetails(int stopId)
    {
        var uri = $"transport/busemtmad/stops/{stopId}/detail/";
        
        _httpClient.DefaultRequestHeaders.Add("accessToken", _accessToken);
        
        HttpResponseMessage response = await _httpClient.GetAsync(uri);
        var stops = await response.Content.ReadFromJsonAsync<ApiResponse<BusStopCollection[]>>();

        if(response.StatusCode != HttpStatusCode.OK)
        {
            //var responseFailure = ProcessHttpStatus(responseStatus: response.StatusCode);
            //throw new DeepSeekException(message: "", failure: responseFailure);
            throw new Exception("Unexpected status code");
        }

        return stops.Content.First().Stops.First();
    }

    public async Task<ArrivalResponse> ArrivalTime(int stopId)
    {
        var uri = $"transport/busemtmad/stops/{stopId}/arrives/";
        
        _httpClient.DefaultRequestHeaders.Add("accessToken", _accessToken);
        
        var payload = JsonSerializer.Serialize(ArrivalRequest.Default, options: _serializerOptions);
        var httpContent = new StringContent(payload, Encoding.UTF8, "application/json");
        
        HttpResponseMessage response = await _httpClient.PostAsync(uri, httpContent);
        var arrivals = await response.Content.ReadFromJsonAsync<ApiResponse<ArrivalDetails[]>>();

        if(response.StatusCode != HttpStatusCode.OK)
        {
            //var responseFailure = ProcessHttpStatus(responseStatus: response.StatusCode);
            //throw new DeepSeekException(message: "", failure: responseFailure);
            throw new Exception("Unexpected status code");
        }

        var arrivalResponse = new ArrivalResponse
        {
            BusArrivals = arrivals.Content.First().BusArrivals,
            StopDetails = arrivals.Content.First().StopInfo.First()
        };

        return arrivalResponse;
    }

    public async Task<List<SearchStop>> StopsAroundVenue(string venueName, int venueNumber = 0, int metersAround = 500)
    {
        var uri = $"transport/busemtmad/stops/arroundstreet/{venueName}/{venueNumber}/{metersAround}/";
        
        _httpClient.DefaultRequestHeaders.Add("accessToken", _accessToken);
        
        HttpResponseMessage response = await _httpClient.GetAsync(uri);
        var searchResult = await response.Content.ReadFromJsonAsync<ApiResponse<List<SearchStop>>>();

        if(response.StatusCode != HttpStatusCode.OK)
        {
            //var responseFailure = ProcessHttpStatus(responseStatus: response.StatusCode);
            //throw new DeepSeekException(message: "", failure: responseFailure);
            throw new Exception("Unexpected status code");
        }

        return searchResult.Content ?? new List<SearchStop>();
    }
}