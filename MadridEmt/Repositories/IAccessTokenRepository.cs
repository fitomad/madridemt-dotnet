using MadridEmt.Entities;
using MadridEmt.Entities.Errors;

namespace MadridEmt.Repositories;

public interface IAccessTokenRepository
{
    void Store(AccessToken token);
    Result<AccessToken, AccessTokenRepositoryError> Fetch();
}