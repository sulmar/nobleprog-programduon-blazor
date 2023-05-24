using FluentValidation;

namespace ProgramDuon.Training.Domain.Validators;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(p => p.Username).NotEmpty();
        RuleFor(p => p.FirstName).NotEmpty();
        RuleFor(p => p.LastName).NotEmpty();
        RuleFor(p => p.Email).NotEmpty().EmailAddress();
        RuleFor(p => p.Password).NotEmpty();
        RuleFor(p => p.ConfirmPassword).NotEmpty().Equal(p=>p.Password);
            
    }
}
