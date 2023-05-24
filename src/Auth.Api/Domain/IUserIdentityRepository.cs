namespace Auth.Api.Domain;

public interface IUserIdentityRepository
{
    UserIdentity GetByUsername(string username);
    IEnumerable<UserIdentity> GetAll();
    Task AddAsync(UserIdentity userIdentity);
}
