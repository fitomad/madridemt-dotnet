using System.Runtime.InteropServices.JavaScript;

namespace MadridEmt.Entities.Errors;

public record AccessTokenRepositoryError(string Message)
{
    public static readonly AccessTokenRepositoryError NonValidAccessToken = new("The access token is not valid yet");
    public static readonly AccessTokenRepositoryError AccessTokenUnavailable = new("No access token available");
}