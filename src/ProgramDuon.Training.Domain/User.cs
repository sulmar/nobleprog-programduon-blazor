using System.ComponentModel.DataAnnotations;

namespace ProgramDuon.Training.Domain;

public class User : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }


    [Compare(nameof(ConfirmPassword))]
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}