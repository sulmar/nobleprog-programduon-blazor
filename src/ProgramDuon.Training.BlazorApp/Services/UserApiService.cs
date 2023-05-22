using ProgramDuon.Training.Domain;
using System.Net.Http.Json;

namespace ProgramDuon.Training.BlazorApp.Services;

public class UserApiService : IUserApiService
{
    private readonly HttpClient _httpClient;
    public UserApiService(HttpClient httpClient) => _httpClient = httpClient;
    public async Task<IEnumerable<User>> GetAllAsync() => await _httpClient.GetFromJsonAsync<IEnumerable<User>>("/api/users");
}

