using Identity.Application.Services;
using Identity.Domain.Entities;
using Identity.Infrastructure.Settings;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Identity.Infrastructure.Services
{
    public class TokenService : ITokenService
    {

        public JwtSettings Settings { get; }


        public TokenService(JwtSettings settings)
        {
            Settings = settings;
        }

        public string GenerateToken(User user)
        {

            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),

            };

            if (user.Roles is not null)
            {
                foreach (var role in user.Roles.Where(r => !string.IsNullOrWhiteSpace(r)))
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Settings.Key));

            var token = new JwtSecurityToken(
                issuer: Settings.Issuer,
                audience: Settings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.Add(Settings.TokenLifeSpan),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenAsString;
        }
    }
}
