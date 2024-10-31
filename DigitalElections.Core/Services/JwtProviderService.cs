using DigitalElections.Core.Interfaces.Services;
using DigitalElections.Core.Utils;
using DigitalElections.Domain.Enums;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DigitalElections.Core.Services;

public class JwtProviderService : IJwtProviderService
{
    public JwtProviderService() { }

    public string GenerateToken(UserTypeEnum role, long userId)
    {
        var handler = new JwtSecurityTokenHandler();

        var key = Encoding.ASCII.GetBytes(Hashing.Key);

        var claims = new List<Claim>()
        {
            new Claim("id", userId.ToString()),
            new Claim(ClaimTypes.Role, role.ToString())
        };

        var descriptor = new SecurityTokenDescriptor
        {
            Expires = DateTime.UtcNow.AddHours(2),
            Subject = new ClaimsIdentity(claims),
            SigningCredentials = new SigningCredentials(
                                 new SymmetricSecurityKey(key),
                                 SecurityAlgorithms.HmacSha256Signature)
        };

        var token = handler.CreateToken(descriptor);

        return handler.WriteToken(token);
    }
}