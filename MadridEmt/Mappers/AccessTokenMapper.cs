using System.Text.Json;
using MadridEmt.Entities;
using MadridEmt.Entities.Errors;

namespace MadridEmt.Mappers;

internal sealed class AccessTokenMapper
{
    internal string StringFromAccessToken(AccessToken accessToken)
    {
        string document = JsonSerializer.Serialize(accessToken);

        return document;
    }

    internal AccessToken AccessTokenFromString(string jsonDocument)
    {
        AccessToken accessToken = JsonSerializer.Deserialize<AccessToken>(jsonDocument);
        
        return accessToken;
    }
}