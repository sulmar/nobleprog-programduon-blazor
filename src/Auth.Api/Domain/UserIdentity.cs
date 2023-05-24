namespace Auth.Api.Domain;

public class UserIdentity
{
    public string UserName { get; set; }
    public string HashedPassword { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string FullName => $"{FirstName} {LastName}";

    public string Email { get; set; }
    public string[] Roles { get; set; }
}
