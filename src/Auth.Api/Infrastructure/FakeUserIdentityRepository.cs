using Auth.Api.Domain;
using Microsoft.AspNetCore.Identity;

namespace Auth.Api.Infrastructure;

public class FakeUserIdentityRepository : IUserIdentityRepository
{
    private readonly IDictionary<string, UserIdentity> _userIdentities;

    public FakeUserIdentityRepository(IEnumerable<UserIdentity> userIdentities,
        IPasswordHasher<UserIdentity> passwordHasher)
    {
        foreach (var userIdentity in userIdentities)
        {
            userIdentity.HashedPassword = passwordHasher.HashPassword(userIdentity, userIdentity.HashedPassword);
        }

        _userIdentities = userIdentities.ToDictionary(p => p.UserName);
    }

    public IEnumerable<UserIdentity> GetAll() => _userIdentities.Values;

    public UserIdentity GetByUsername(string username)
    {
        if (_userIdentities.TryGetValue(username, out var userIdentity))
        {
            return userIdentity;
        }
        else
        {
            return null;
        }
    }
}
