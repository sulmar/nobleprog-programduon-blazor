using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.IdentityModel.Tokens;
using ProgramDuon.Training.BlazorApp.Models;
using ProgramDuon.Training.BlazorApp.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProgramDuon.Training.BlazorApp.Authentication;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly IAuthApiService api;
    private readonly ILocalStorageService localStorageService;

    private const string TokenKey = "token";

    public CustomAuthenticationStateProvider(IAuthApiService api, ILocalStorageService localStorageService)
    {
        this.api = api;
        this.localStorageService = localStorageService;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var state = new AuthenticationState(new System.Security.Claims.ClaimsPrincipal());

        var token = await localStorageService.GetItemAsStringAsync(TokenKey);

        if (!string.IsNullOrEmpty(token))
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            if (tokenHandler.CanReadToken(token))
            {
                var jwtToken = tokenHandler.ReadJwtToken(token);
                var secretKey = "your-256-bit-secret-your-256-bit-secret";
                var key = Encoding.ASCII.GetBytes(secretKey);

                try
                {
                    tokenHandler.ValidateToken(token, new TokenValidationParameters
                    {
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateLifetime = true,

                    }, out var validatedToken);

                    var identity = new ClaimsIdentity(jwtToken.Claims, "JWT Token");
                    state = new AuthenticationState(new ClaimsPrincipal(identity));

                }
                catch (Exception ex)
                {

                }




            }
        }



        // dotnet add package System.IdentityModel.Tokens.Jwt

        return state;
    }

    public async Task LoginAsync(LoginModel model)
    {
        var token = await api.CreateTokenAsync(model);

        await localStorageService.SetItemAsStringAsync(TokenKey, token);

        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    public async Task LogoutAsync()
    {
        await localStorageService.RemoveItemAsync(TokenKey);
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}
