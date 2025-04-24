using MadridEmt.Entities.Login;

namespace MadridEmt.Endpoints.Auth;

public interface IAuthEndpoint
{
    Task<Login> Login();
    Task Logout();
    Task<Login> WhoAmI();
}