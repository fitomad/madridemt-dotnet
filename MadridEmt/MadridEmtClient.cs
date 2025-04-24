using MadridEmt.Entities.Login;
using MadridEmt.Endpoints.Auth;
using MadridEmt.Endpoints.Bus;
using MadridEmt.Entities;
using MadridEmt.Repositories;
using Microsoft.Extensions.Logging;

namespace MadridEmt;

public interface IMadridEmtClient
{
    IAuthEndpoint Authentication { get; }
    IBusEndpoint Bus { get; }
}

public class MadridEmtClient: IMadridEmtClient
{
    private readonly HttpClient _httpClient;
    private readonly IAccessTokenRepository _repository;
    private string _accessToken;
    
    public IAuthEndpoint Authentication => new AuthEndpoint(httpClient: _httpClient, accessToken: _accessToken);
    public IBusEndpoint Bus => new  BusEndpoint(httpClient: _httpClient, accessToken: _accessToken);

    public MadridEmtClient(HttpClient client, IAccessTokenRepository repository)
    {
        _httpClient = client;
        _repository = repository;
        
        Task.Run(FetchAccessToken).Wait();
    }

    private async Task FetchAccessToken()
    {
        var accessTokenResult = _repository.Fetch();

        if(accessTokenResult.IsSuccess)
        {
            _accessToken = accessTokenResult.Value.Token;
        }
        else
        {
             Login loginResponse = await Authentication.Login();

             var accessToken = new AccessToken
             {
                Token = loginResponse.AccessToken,
                Expiration = DateTime.UtcNow.AddSeconds(loginResponse.AccessTokenLifetime)
             };
             
             _repository.Store(accessToken);
             _accessToken = accessToken.Token;
        }
    }
}
