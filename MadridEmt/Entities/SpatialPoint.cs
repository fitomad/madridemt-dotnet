using System.Text.Json.Serialization;

namespace MadridEmt.Entities;

public record SpatialPoint
{
    [JsonPropertyName("type")]
    public string Type { get; init; }
    [JsonPropertyName("coordinates")]
    public double[] Coordinates { get; init; }
    
    public double Latitude => Coordinates[0];
    public double Longitude =>  Coordinates[1];
}