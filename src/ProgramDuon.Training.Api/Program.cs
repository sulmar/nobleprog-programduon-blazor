using ProgramDuon.Training.Domain;
using ProgramDuon.Training.Domain.Abstractions;
using ProgramDuon.Training.Infrastructure;
using ProgramDuon.Training.Infrastructure.Fakers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IDeviceRepository, FakeDeviceRepository>();
builder.Services.AddSingleton<IUserRepository, FakeUserRepository>();

//builder.Services.AddSingleton<IEnumerable<Device>>(sp => new List<Device>
//{
//    new Device { Id = 1, Name = "Device 1" , Description = "Lorem ipsum 1" },
//    new Device { Id = 2, Name = "Device 2" , Description = "Lorem ipsum 2" },
//    new Device { Id = 3, Name = "Device 3" , Description = "Lorem ipsum 3" },

//});

builder.Services.AddSingleton<IEnumerable<Device>>(sp =>
{
    var faker = new DeviceFaker();
    var devices = faker.Generate(100);
    return devices;
});

builder.Services.AddSingleton<IEnumerable<User>>(sp =>
{
    var faker = new UserFaker();
    var users = faker.Generate(10);
    return users;
});


// CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        // policy.AllowAnyOrigin();
        policy.WithOrigins("https://localhost:7161", "http://localhost:5219" );
        policy.WithMethods(new string[] { "GET" });
        policy.AllowAnyHeader();
    });

});
    

var app = builder.Build();

app.UseCors();

app.MapGet("/", () => "Hello World!");

// GET api/devices
app.MapGet("/api/devices", async (IDeviceRepository repository) => await repository.GetAllAsync());


// GET api/users
app.MapGet("/api/users", async (IUserRepository repository) => await repository.GetAllAsync());

app.Run();
