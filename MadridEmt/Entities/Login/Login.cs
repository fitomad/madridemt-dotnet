using System.Text.Json.Serialization;

namespace MadridEmt.Entities.Login;

public record Login
{
    [JsonPropertyName("XClientId")]
    public string ClientId { get; set; }
    [JsonPropertyName("updatedAt")]
    public DateTime UpdatedAt { get; set; }
    [JsonPropertyName("nameApp")]
    public string ApplicationName { get; set; }
    [JsonPropertyName("userName")]
    public string UserName { get; set; }
    [JsonPropertyName("idUser")]
    public string UserId { get; set; }
    [JsonPropertyName("email")]
    public string Email { get; set; }
    [JsonPropertyName("accessToken")]
    public string AccessToken { get; set; }
    [JsonPropertyName("tokenSecExpiration")]
    public int AccessTokenLifetime { get; set; }
    [JsonPropertyName("apiCounter")]
    public ApiRateCounter RateLimitStatus  { get; set; }
}