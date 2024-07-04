using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NumberToWords.API.Models;
using NumberToWords.Domain.Models.Jwt;
using NumberToWords.Domain.Models.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NumberToWords.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        //private readonly string secretKey;
        private readonly IJwtTokenService _jwtTokenService;

        public AuthenticateController(IJwtTokenService jwtTokenService)
        {
            _jwtTokenService = jwtTokenService;
            //secretKey = jwtSettings.Value.SecretKey ?? throw new InvalidOperationException("JWT_SECRET is not configured");
        }

        [HttpPost]
        public IActionResult GetToken([FromBody] UserRequest user)
        {
            
            if (user.UserName == "user" && user.Password == "123") // Valida tus credenciales
            {
                var token = _jwtTokenService.GenerateToken(user.UserName);
                return Ok(new { Token = token });
            }

            return Unauthorized("Invalid credentials");
        }

    }
}
