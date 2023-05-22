using ProgramDuon.Training.Domain;

namespace ProgramDuon.Training.BlazorApp.Services;

public interface IUserApiService
{
    Task<IEnumerable<User>> GetAllAsync();
}

