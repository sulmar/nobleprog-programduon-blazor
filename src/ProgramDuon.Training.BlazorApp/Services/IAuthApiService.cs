using ProgramDuon.Training.BlazorApp.Models;

namespace ProgramDuon.Training.BlazorApp.Services;

public interface IAuthApiService 
{
    Task<string> CreateTokenAsync(LoginModel model);
}
