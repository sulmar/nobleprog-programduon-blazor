using Auth.Api.Domain;
using Auth.Api.Infrastructure;
using Auth.Api.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IEnumerable<UserIdentity>>(sp =>
{
    var users = new List<UserIdentity>
    {
        new UserIdentity {
            UserName = "john",
            Email="john.smith@domain.com",
            FirstName="John",
            LastName="Smith",
            HashedPassword = "123",
            Roles = new string[] { "administrator"},
            Avatar = "http://simpleicon.com/wp-content/uploads/business-man-1.svg"
        },

         new UserIdentity {
            UserName = "kate",
            Email="kate.smith@domain.com",
            FirstName="Kate",
            LastName="Smith",
            HashedPassword = "123" ,
            Roles = new string[] { "developer"},
            Avatar = "http://simpleicon.com/wp-content/uploads/business-woman-2.svg"
        },

          new UserIdentity {
            UserName = "bob",
            Email="bob.smith@domain.com",
            FirstName="Bob",
            LastName="Smith",
            HashedPassword = "123",
            Roles = new string[] { "administrator", "developer"},
            Avatar = "http://simpleicon.com/wp-content/uploads/business-man-2.svg"
        },

    };

    return users;

});

builder.Services.AddSingleton<IUserIdentityRepository, FakeUserIdentityRepository>();
builder.Services.AddSingleton<IAuthService, AuthService>();
builder.Services.AddSingleton<ITokenService, JwtTokenService>();
builder.Services.AddSingleton<IPasswordHasher<UserIdentity>, PasswordHasher<UserIdentity>>();


// CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        // policy.AllowAnyOrigin();
        policy.WithOrigins("https://localhost:7161", "http://localhost:5219");
        policy.WithMethods(new string[] { "GET" });
        policy.AllowAnyHeader();
    });

});

var app = builder.Build();

app.UseCors();

app.MapGet("/", () => "Hello Auth.Api!");

// app.MapGet("/users", (IUserIdentityRepository repository) => repository.GetAll());


app.MapPost("/api/token/create", (LoginModel model,
    IAuthService authService,
    ITokenService tokenService) =>
{
    if (authService.TryAuthorize(model.UserName, model.Password, out var identity))
    {
        var token = tokenService.Create(identity);

        return Results.Ok(token);
    }

    return Results.BadRequest(new { message = "Invalid username or password" });

});

app.Run();
