using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NumberToWords.Domain.Models.Jwt;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NumberToWords.Infrastructure.Services
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly JwtSettings _jwtSettings;

        public JwtTokenService(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        public string GenerateToken(string userName)
        {
            var keyBytes = Encoding.UTF8.GetBytes(_jwtSettings.SecretKey);
            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, userName)
        };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(
                                      new SymmetricSecurityKey(keyBytes),
                                      SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
