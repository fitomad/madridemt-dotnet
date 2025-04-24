using System.Net;
using System.Net.Http.Json;

using MadridEmt.Entities;
using MadridEmt.Entities.Login;

namespace MadridEmt.Endpoints.Auth;

public class AuthEndpoint: IAuthEndpoint
{
    private readonly HttpClient _httpClient;
    private readonly string _accessToken;
    
    internal AuthEndpoint(HttpClient httpClient, string accessToken)
    {
        _httpClient = httpClient;
        _accessToken = accessToken;
    }
    
    public async Task<Login> Login()
    {
        HttpResponseMessage response = await _httpClient.GetAsync(AuthUri.Login);
        var loginResponse = await response.Content.ReadFromJsonAsync<ApiResponse<Login[]>>();

        if(response.StatusCode != HttpStatusCode.OK)
        {
            //var responseFailure = ProcessHttpStatus(responseStatus: response.StatusCode);
            //throw new DeepSeekException(message: "", failure: responseFailure);
            throw new Exception("Unexpected status code");
        }

        return loginResponse.Content.First();
    }

    public async Task Logout()
    {
        HttpResponseMessage response = await _httpClient.GetAsync(AuthUri.Logout);
        
        if(response.StatusCode != HttpStatusCode.OK)
        {
            //var responseFailure = ProcessHttpStatus(responseStatus: response.StatusCode);
            //throw new DeepSeekException(message: "", failure: responseFailure);
            throw new Exception("Unexpected status code");
        }

    }

    public async Task<Login> WhoAmI()
    {
        HttpResponseMessage response = await _httpClient.GetAsync(AuthUri.WhoAmI);
        var whoResponse = await response.Content.ReadFromJsonAsync<ApiResponse<Login[]>>();

        if(response.StatusCode != HttpStatusCode.OK)
        {
            //var responseFailure = ProcessHttpStatus(responseStatus: response.StatusCode);
            //throw new DeepSeekException(message: "", failure: responseFailure);
            throw new Exception("Unexpected status code");
        }
        
        return whoResponse.Content.First();
    }
}