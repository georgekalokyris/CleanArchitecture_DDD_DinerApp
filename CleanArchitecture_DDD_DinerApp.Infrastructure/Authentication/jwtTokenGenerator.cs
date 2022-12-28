using CleanArchitecture_DDD_DinerApp.Application.Common.Authentication;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CleanArchitecture_DDD_DinerApp.Infrastructure.Authentication;
public class jwtTokenGenerator : IjwtTokenGenerator
{
    public string GenerateToken(Guid userId, string firstName, string lastName)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super-secret-key")),
                                     SecurityAlgorithms.HmacSha256
            );

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, firstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var securityToken = new JwtSecurityToken(
            issuer: "CleanArchitecture_DDD_DinerApp",
            expires: DateTime.Now.AddDays(1),
            claims: claims,
            signingCredentials: signingCredentials) ;

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}
