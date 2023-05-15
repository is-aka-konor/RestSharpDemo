using System.Text.Json.Serialization;

namespace RestSharpDemo.Console.Auth;

public class JwtResponse
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; } = string.Empty;
    public string Scope { get; set; } = string.Empty;
    [JsonPropertyName("expires_in")]
    public int ExpiresIn { get; set; }
    [JsonPropertyName("token_type")]
    public string TokenType { get; set; } = string.Empty;
    private DateTime _validFrom = DateTime.Now;
    public bool IsValid => DateTime.Now < _validFrom.AddSeconds(ExpiresIn);
}