using Bogus;
using ProgramDuon.Training.Domain;

namespace ProgramDuon.Training.Infrastructure.Fakers;

public class UserFaker : Faker<User>
{
    public UserFaker()
    {
        StrictMode(true);
        RuleFor(p => p.Id, f => f.IndexFaker);
        RuleFor(p => p.Username, f => f.Person.UserName);
        RuleFor(p => p.FirstName, f => f.Person.FirstName);
        RuleFor(p => p.LastName, f => f.Person.LastName);
        RuleFor(p => p.Email, (f, user) => $"{user.FirstName}.{user.LastName}@programduo.se"); // {firstname}.{lastname}@programduo.se

        Ignore(p => p.Password);
        Ignore(p => p.ConfirmPassword);
    }
}
