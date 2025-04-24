using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using MadridEmt.Entities.Bus;
using MadridEmt.Entities.Bus.Arrivals;
using MadridEmt.Entities.Bus.Search;
using MadridEmt.Extensions;

namespace MadridEmt.Tests;

public class BusTests
{
    private readonly IMadridEmtClient _client;
    
    public BusTests()
    {
        var userSecretsConfiguration = new ConfigurationBuilder()
            .AddUserSecrets<BusTests>()
            .Build();

        string clientId = userSecretsConfiguration.GetValue<string>("MadridEmt:ClientId");
        string passKey = userSecretsConfiguration.GetValue<string>("MadridEmt:PassKey");

        var testSettings = new Settings
        {
            ClientId = clientId,
            PassKey = passKey
        };

        var services = new ServiceCollection();
        services.AddMadridEmt(settings: testSettings);
        var provider = services.BuildServiceProvider();
        
        _client = provider.GetRequiredService<IMadridEmtClient>();    
    }

    [Theory]
    [InlineData(1433)]
    [InlineData(5718)]
    [InlineData(558)]
    [InlineData(914)]
    [InlineData(82)]
    [InlineData(73)]
    [InlineData(5683)]
    public async Task TestBusStopDetails(int stopId)
    {
        BusStop stop = await _client.Bus.StopDetails(stopId);
        
        Assert.NotEmpty(stop.Name);
        Assert.NotEmpty(stop.Lines);
        Assert.Equal(stopId, stop.StopId);
    }

    [Theory]
    [InlineData(1433)]
    [InlineData(5718)]
    [InlineData(558)]
    [InlineData(914)]
    [InlineData(82)]
    [InlineData(73)]
    [InlineData(5683)]
    public async Task TestArrivals(int stopId)
    {
        ArrivalResponse response = await _client.Bus.ArrivalTime(stopId: stopId);

        Assert.NotNull(response);
        Assert.NotEmpty(response.BusArrivals);
        Assert.NotNull(response.StopDetails);
    }
    
    [Theory]
    [InlineData("Plaza Ruiz Picasso")]
    [InlineData("Puerta del Sol")]
    [InlineData("Callao")]
    [InlineData("Faro de Moncloa")]
    public async Task TestSearchBusStopByVenue(string venue)
    {
        List<SearchStop> searchResult = await _client.Bus.StopsAroundVenue(venue);

        Assert.NotNull(searchResult);
    }
    
    [Theory]
    [InlineData("Plaza Ruiz Picasso", 0)]
    [InlineData("Puerta del Sol", 3)]
    [InlineData("Callao", 0)]
    [InlineData("Faro de Moncloa", 0)]
    public async Task TestSearchBusStopByVenueAndNumber(string venueName, int number)
    {
        List<SearchStop> searchResult = await _client.Bus.StopsAroundVenue(venueName, number);

        Assert.NotNull(searchResult);
    }
    
    [Theory]
    [InlineData("Plaza Ruiz Picasso", 0, 500)]
    [InlineData("Puerta del Sol", 3, 200)]
    [InlineData("Callao", 0, 1_000)]
    [InlineData("Faro de Moncloa", 0, 500)]
    public async Task TestSearchBusStopByVenueAndNumberAndRadius(string venueName, int number, int radius)
    {
        List<SearchStop> searchResult = await _client.Bus.StopsAroundVenue(venueName, number, radius);

        Assert.NotNull(searchResult);
    }
    
    [Fact]
    public async Task TestSearchBusStopNoResults()
    {
        List<SearchStop> searchResult = await _client.Bus.StopsAroundVenue("Callao", 0, 1);

        Assert.Empty(searchResult);
    }
}