using System.Text.Json.Serialization;

namespace MadridEmt.Entities;

public class ApiResponse<Element>
{
    [JsonPropertyName("code")]
    public string Code { get; set; }
    [JsonPropertyName("description")]
    public string Description { get; set; }
    [JsonPropertyName("datetime")]
    public DateTime CreatedAt { get; set; }
    [JsonPropertyName("data")]
    public Element Content { get; set; }
}