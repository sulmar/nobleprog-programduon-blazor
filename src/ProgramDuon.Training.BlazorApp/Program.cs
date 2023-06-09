using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ProgramDuon.Training.BlazorApp;
using ProgramDuon.Training.BlazorApp.Authentication;
using ProgramDuon.Training.BlazorApp.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// dotnet add package Microsoft.Extensions.Http
builder.Services.AddHttpClient<IDeviceApiService, DeviceApiService>(sp => sp.BaseAddress = new Uri("https://localhost:7006"));

builder.Services.AddHttpClient<IUserApiService, UserApiService>(sp => sp.BaseAddress = new Uri("https://localhost:7006"));


builder.Services.AddHttpClient<IAuthApiService, AuthApiService>(sp => sp.BaseAddress = new Uri("https://localhost:7015"));

builder.Services.AddAuthorizationCore();

// builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

builder.Services.AddScoped<CustomAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<CustomAuthenticationStateProvider>());

// dotnet add package Blazored.LocalStorage
builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
