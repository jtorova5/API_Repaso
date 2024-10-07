using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using RepasoAPI.Models;

namespace RepasoAPI.Config;

public class Utilities
{
    public string EncryptSHA256(string input)
    {
        byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(input));
        StringBuilder builder = new();
        for (int i = 0; i < bytes.Length; i++)
        {
            builder.Append(bytes[i].ToString("x2"));
        }
        return builder.ToString();
    }

    public string GenerateJwtToken(Customer user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
            new Claim(ClaimTypes.Email,user.Email),
        };

        var jwtKey = Environment.GetEnvironmentVariable("JWT_KEY");
        var jwtIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER");
        var jwtAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE");
        var jwtExpiresIn = Environment.GetEnvironmentVariable("JWT_EXPIRES_IN");

        if (string.IsNullOrEmpty(jwtKey) || string.IsNullOrEmpty(jwtIssuer) || string.IsNullOrEmpty(jwtAudience))
        {
            throw new InvalidOperationException("JWT configuration values are missing.");
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: jwtIssuer,
            audience: jwtAudience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtExpiresIn)),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}