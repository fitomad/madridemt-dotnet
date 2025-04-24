using MadridEmt.Entities;
using MadridEmt.Entities.Errors;
using MadridEmt.Mappers;

namespace MadridEmt.Repositories;

public class EnvironmentVariableRepository: IAccessTokenRepository
{
    private const string EnvironmentVariableKey = "MadridEmt:AccessToken";
    private readonly AccessTokenMapper _accessTokenMapper = new();
    
    public void Store(AccessToken token)
    {
        string tokenJsonRepresentation = _accessTokenMapper.StringFromAccessToken(token);
        Environment.SetEnvironmentVariable(EnvironmentVariableKey, tokenJsonRepresentation);
    }

    public Result<AccessToken, AccessTokenRepositoryError> Fetch()
    {
        string? tokenJsonRepresentation = Environment.GetEnvironmentVariable(EnvironmentVariableKey);

        if(tokenJsonRepresentation is not null)
        {
            AccessToken accessToken = _accessTokenMapper.AccessTokenFromString(tokenJsonRepresentation);

            if(accessToken.IsValid)
            {
                return Result<AccessToken, AccessTokenRepositoryError>.Success(accessToken);
            }

            return Result<AccessToken, AccessTokenRepositoryError>.Failure(AccessTokenRepositoryError.NonValidAccessToken);
        }

        return Result<AccessToken, AccessTokenRepositoryError>.Failure(AccessTokenRepositoryError.AccessTokenUnavailable);
    }
}