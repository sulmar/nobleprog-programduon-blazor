using ProgramDuon.Training.Domain;
using System.Net.Http;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace ProgramDuon.Training.BlazorApp.Services;

public class DeviceApiService : IDeviceApiService
{
    private readonly HttpClient _httpClient;
    public DeviceApiService(HttpClient httpClient) => _httpClient = httpClient;
    public async Task<IEnumerable<Device>> GetAllAsync() => await _httpClient.GetFromJsonAsync<IEnumerable<Device>>("/api/devices");
    public async Task<Device> GetByIdAsync(int id) => await _httpClient.GetFromJsonAsync<Device>($"/api/devices/{id}");
}

