using Auth.Api.Domain;
using Microsoft.AspNetCore.Identity;

namespace Auth.Api.Infrastructure;

public class FakeUserIdentityRepository : IUserIdentityRepository
{
    private readonly IDictionary<string, UserIdentity> _userIdentities;
    private readonly IPasswordHasher<UserIdentity> passwordHasher;

    public FakeUserIdentityRepository(IEnumerable<UserIdentity> userIdentities,
        IPasswordHasher<UserIdentity> passwordHasher)
    {
        foreach (var userIdentity in userIdentities)
        {
            userIdentity.Password = passwordHasher.HashPassword(userIdentity, userIdentity.Password);
        }

        _userIdentities = userIdentities.ToDictionary(p => p.UserName);
        this.passwordHasher = passwordHasher;
    }

    public Task AddAsync(UserIdentity userIdentity)
    {
        userIdentity.Password = passwordHasher.HashPassword(userIdentity, userIdentity.Password);

        userIdentity.Avatar = UserIdentity.DefaultAvatar;

        _userIdentities.Add(userIdentity.UserName, userIdentity);

        return Task.CompletedTask;
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
