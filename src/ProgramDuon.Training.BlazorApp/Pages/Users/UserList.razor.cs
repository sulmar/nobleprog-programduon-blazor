using Microsoft.AspNetCore.Components;
using ProgramDuon.Training.BlazorApp.Services;
using ProgramDuon.Training.Domain;

namespace ProgramDuon.Training.BlazorApp.Pages.Users;

public partial class UserList : ComponentBase
{
    [Inject]
    public IUserApiService Api { get; set; }

    private IEnumerable<User> users;
   
    protected override async Task OnInitializedAsync()
    {
        users = await Api.GetAllAsync();
    }
}
