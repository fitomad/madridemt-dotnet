using System.Text.Json.Serialization;

namespace MadridEmt.Entities;

public struct AccessToken
{
    [JsonRequired]
    [JsonPropertyName("access-token")]
    public string Token { get; init; }
    [JsonRequired]
    [JsonPropertyName("expires-at")]
    public DateTime Expiration { get; init; }
    
    public bool IsValid => Expiration < DateTime.UtcNow;
}