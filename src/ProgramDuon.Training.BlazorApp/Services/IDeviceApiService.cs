using ProgramDuon.Training.Domain;

namespace ProgramDuon.Training.BlazorApp.Services;

public interface IDeviceApiService
{
    Task<IEnumerable<Device>> GetAllAsync();
    Task<Device> GetByIdAsync(int id);
}

