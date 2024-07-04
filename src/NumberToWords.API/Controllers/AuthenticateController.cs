using Microsoft.AspNetCore.Mvc;
using NumberToWords.API.Models;
using NumberToWords.Domain.Models.Jwt;

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
