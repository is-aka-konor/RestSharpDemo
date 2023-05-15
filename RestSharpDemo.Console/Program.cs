using Microsoft.Extensions.Configuration;
using RestSharp;
using RestSharpDemo.Console.Auth;

// See https://aka.ms/new-console-template for more information
// read the appsettings.json file

var builder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
// read identity configuration using Options pattern
var configuration = builder.Build();
var identityConfig = new IdentityConfig();
configuration.GetSection(identityConfig.SectionName).Bind(identityConfig);
// create the authenticator
var authenticator = new IdentityAuthenticator(identityConfig);
var options = new RestClientOptions("http://example.com") {
    Authenticator = authenticator
};
// create RestSharp client and query the API using Jwt authentication
var client = new RestClient(options);
var request = new RestRequest("api/endpoint");
// add query parameters
var parameters = new Dictionary<string, string>()
    { { "col", "Name"}};
foreach (var parameter in parameters)
{
    request.AddQueryParameter(parameter.Key, parameter.Value);   
}

var response = await client.GetAsync(request);
// Handle the response
if (response.IsSuccessful)
{
    var content = response.Content;
    Console.WriteLine(content);
}
else
{
    Console.WriteLine(response.ErrorMessage);
}
Console.WriteLine("Completed!");