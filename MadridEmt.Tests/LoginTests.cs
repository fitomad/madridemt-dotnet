using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using MadridEmt.Entities.Login;
using MadridEmt.Extensions;

namespace MadridEmt.Tests;

public class LoginTests
{
    private readonly IMadridEmtClient _client;
    
    public LoginTests()
    {
        var userSecretsConfiguration = new ConfigurationBuilder()
            .AddUserSecrets<LoginTests>()
            .Build();

        string clientId = userSecretsConfiguration.GetValue<string>("MadridEmt:ClientId");
        string passKey = userSecretsConfiguration.GetValue<string>("MadridEmt:PassKey");

        var testSettings = new Settings
        {
            ClientId = clientId,
            PassKey = passKey
        };

        var services = new ServiceCollection();
        services.AddMadridEmt(settings: testSettings);
        var provider = services.BuildServiceProvider();
        
        _client = provider.GetRequiredService<IMadridEmtClient>();    
    }
    
    [Fact]
    public async Task TestLogin()
    {
        Login login = await _client.Authentication.Login();
        
        Assert.Equal(250_000, login.RateLimitStatus.DailyRequestLimit);
        Assert.NotEmpty(login.ClientId);
        Assert.NotEmpty(login.AccessToken);
    }
}
