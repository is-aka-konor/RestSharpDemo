using RestSharp;
using RestSharp.Authenticators;

namespace RestSharpDemo.Console.Auth;

public class IdentityAuthenticator : AuthenticatorBase
{
    private readonly IdentityConfig _identityConfig;
    private readonly IRestClient _client;
    private JwtResponse _jwt = new JwtResponse();

    public IdentityAuthenticator(IdentityConfig identityConfig) : base("")
    {
        _identityConfig = identityConfig;
        _client = new RestClient();
    }
    
    /// <summary>
    /// Retrieve a JWT from the identity server
    /// </summary>
    /// <returns>JWT access token as a <see cref="string"/>string</returns>
    public async Task<string> GetJwtAsync()
    {
        if (!_jwt.IsValid)
        {
            // get the token from the identity server
            var request = new RestRequest(_identityConfig.Authority);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("client_id", _identityConfig.ClientId);
            request.AddParameter("client_secret", _identityConfig.ClientSecret);
            request.AddParameter("grant_type", _identityConfig.GrantType);
            request.AddParameter("scope", _identityConfig.Scope);
            var response = await _client.PostAsync<JwtResponse>(request);
            _jwt = response ?? throw new ApplicationException("Unable to retrieve JWT");
        }
        return _jwt?.AccessToken ?? string.Empty;
    }

    protected override async ValueTask<Parameter> GetAuthenticationParameter(string accessToken)
    {
        Token = string.IsNullOrEmpty(Token) ? await GetJwtAsync() : Token;
        return new HeaderParameter(KnownHeaders.Authorization, Token);
    }
}