using Auth.Api.Domain;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Auth.Api.Infrastructure;

// dotnet add package System.IdentityModel.Tokens.Jwt
public class JwtTokenService : ITokenService
{
    public string Create(UserIdentity userIdentity)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, userIdentity.FullName),
            new Claim(ClaimTypes.NameIdentifier, userIdentity.UserName),
            new Claim(ClaimTypes.Email, userIdentity.Email)
        };

        foreach (var role in userIdentity.Roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var secretKey = "your-256-bit-secret-your-256-bit-secret";
        var key = Encoding.ASCII.GetBytes(secretKey);

        var credentials = new SymmetricSecurityKey(key);
        var signingCredentials = new SigningCredentials(credentials, SecurityAlgorithms.HmacSha256Signature);

        var token = new JwtSecurityToken(
                  claims: claims,
                  expires: DateTime.Now.AddDays(1),
                  signingCredentials: signingCredentials
              );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);        

        return jwt;
    }
}
