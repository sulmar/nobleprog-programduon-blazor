using System.Security.Claims;
using System.Security.Principal;

namespace ProgramDuon.Training.BlazorApp.Authentication;

public static class ClaimsIdentityExtensions
{

    public static string GetAvatar(this IIdentity identity) => GetCustomClaimValue(identity, "avatar");

    public static string GetCustomClaimValue(this IIdentity identity, string claimType)
    {
        var claim = ((ClaimsIdentity) identity).Claims.FirstOrDefault(c => c.Type == claimType);

        return claim?.Value;
    }
}
