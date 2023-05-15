namespace RestSharpDemo.Console.Auth;

public class IdentityConfig
{
    public readonly string SectionName = nameof(IdentityConfig);
    public string ClientId { get; set; } = string.Empty;
    public string ClientSecret { get; set; } = string.Empty;
    public string Authority { get; set; } = string.Empty;
    public string GrantType { get; set; } = string.Empty;
    public string Scope { get; set; } = string.Empty;
}