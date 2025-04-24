namespace MadridEmt.Entities.Bus.Arrivals;

public record ArrivalResponse
{
    public List<BusArrival> BusArrivals { get; init; }
    public ArrivalStop StopDetails { get; init; }
}