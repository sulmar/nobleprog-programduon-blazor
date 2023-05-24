namespace Auth.Api.Domain;

public class UserIdentity
{
    public string UserName { get; set; }
    public string Password { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string FullName => $"{FirstName} {LastName}";

    public string Email { get; set; }
    public string[] Roles { get; set; } = Array.Empty<string>();
    public string Avatar { get; set; }

    public static string DefaultAvatar => "http://simpleicon.com/wp-content/uploads/user1.svg";
}
