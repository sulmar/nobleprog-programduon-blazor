using System.ComponentModel.DataAnnotations;

namespace ProgramDuon.Training.Domain;

public class User : BaseEntity
{
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Avatar { get; set; }

    [Compare(nameof(ConfirmPassword))]
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public string HashedPassword { get; set; }
}