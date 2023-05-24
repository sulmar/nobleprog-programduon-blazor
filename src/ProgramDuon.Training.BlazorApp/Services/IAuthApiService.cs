using ProgramDuon.Training.BlazorApp.Models;
using ProgramDuon.Training.Domain;

namespace ProgramDuon.Training.BlazorApp.Services;

public interface IAuthApiService 
{
    Task<string> CreateTokenAsync(LoginModel model);
    Task AddAsync(User user);
}
