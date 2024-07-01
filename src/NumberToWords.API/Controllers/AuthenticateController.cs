using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NumberToWords.API.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NumberToWords.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly string secretKey;

        public AuthenticateController(IOptions<JwtSettings> jwtSettings)
        {
            secretKey = jwtSettings.Value.SecretKey ?? throw new InvalidOperationException("JWT_SECRET is not configured");
        }

        [HttpPost]
        public IActionResult GetToken([FromBody] User user)
        {
            const string defaultUserName = "user";
            const string defaulPassword = "123";

            if (user.UserName != defaultUserName || user.Password != defaulPassword)
            {
                return Unauthorized("UserName or password does not match");
            }

            var keyBytes = Encoding.UTF8.GetBytes(secretKey);
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserName)
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(
                                     new SymmetricSecurityKey(keyBytes),
                                     SecurityAlgorithms.HmacSha256Signature)};

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtConfig = tokenHandler.CreateToken(tokenDescriptor);
            string jwtToken = tokenHandler.WriteToken(jwtConfig);

            return Ok(new { token = jwtToken });
        }

    }
}
