using MadridEmt.Repositories;
using System.Net.Http.Headers;
using Microsoft.Extensions.DependencyInjection;

namespace MadridEmt.Extensions;

public static class ServiceCollection_MadridEmt
{
    private const string ClientIdHeaderName = "X-ClientId";
    private const string PassKeyHeaderName = "passKey";
    
    public static void AddMadridEmt(this IServiceCollection services, Settings settings)
    {
        // DI 
        services.AddTransient<IAccessTokenRepository, EnvironmentVariableRepository>();
        // HTTP
        services.AddHttpClient<IMadridEmtClient, MadridEmtClient>(client =>
        {
            var emtBaseAddress = "https://openapi.emtmadrid.es/v2/";
            client.BaseAddress = new Uri(emtBaseAddress);
            
            var jsonMediaType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(jsonMediaType);
            
            client.DefaultRequestHeaders.Add(ClientIdHeaderName, settings.ClientId);
            client.DefaultRequestHeaders.Add(PassKeyHeaderName, settings.PassKey);
        });
    }
}