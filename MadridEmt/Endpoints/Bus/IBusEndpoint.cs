using MadridEmt.Entities.Bus;
using MadridEmt.Entities.Bus.Arrivals;
using MadridEmt.Entities.Bus.Search;

namespace MadridEmt.Endpoints.Bus;

public interface IBusEndpoint
{
    Task<BusStop> StopDetails(int stopId);
    Task<ArrivalResponse> ArrivalTime(int stopId);
    Task<List<SearchStop>> StopsAroundVenue(string venueName, int venuNumber = 0, int metersAround = 500);
}