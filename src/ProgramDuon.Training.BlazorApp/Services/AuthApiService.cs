﻿using ProgramDuon.Training.BlazorApp.Models;
using ProgramDuon.Training.BlazorApp.Shared;
using ProgramDuon.Training.Domain;
using System.Net.Http.Json;

namespace ProgramDuon.Training.BlazorApp.Services;

public class AuthApiService : IAuthApiService
{
    private readonly HttpClient httpClient;

    public AuthApiService(HttpClient httpClient) => this.httpClient = httpClient;

    public async Task<string> CreateTokenAsync(LoginModel model)
    {
        var response = await httpClient.PostAsJsonAsync("/api/token/create", model);

        var token = await response.Content.ReadFromJsonAsync<string>();

        return token;
    }

    public async Task AddAsync(User user)
    {
        var response = await httpClient.PostAsJsonAsync("/api/users", user);
    }

}
