using Auth.Api.Domain;
using Microsoft.AspNetCore.Identity;

namespace Auth.Api.Infrastructure;

public class AuthService : IAuthService
{
    private readonly IUserIdentityRepository _userIdentityRepository;
    private readonly IPasswordHasher<UserIdentity> passwordHasher;

    public AuthService(IUserIdentityRepository userIdentityRepository, IPasswordHasher<UserIdentity> passwordHasher)
    {
        _userIdentityRepository = userIdentityRepository;
        this.passwordHasher = passwordHasher;
    }

    public bool TryAuthorize(string username, string password, out UserIdentity userIdentity)
    {
        userIdentity = _userIdentityRepository.GetByUsername(username);

        return userIdentity is not null && 
            passwordHasher.VerifyHashedPassword(userIdentity, userIdentity.Password, password) == PasswordVerificationResult.Success;
    }
}
