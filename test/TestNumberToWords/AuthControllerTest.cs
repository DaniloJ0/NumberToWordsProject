using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NumberToWords.API.Controllers;
using NumberToWords.API.Models;
using NumberToWords.Domain.Models.Jwt;
using NumberToWords.Domain.Models.User;
using NumberToWords.Infrastructure.Services;

namespace TestNumberToWords
{
    public class AuthControllerTest
    {
        private AuthenticateController _authController;
        private IJwtTokenService _jwtTokenService;
        
        [SetUp]
        public void Setup()
        {
            var jwtSettings = new JwtSettings
            {
                SecretKey = "2bb80d537b1da3e38bd30361aa855686bde0eacd7162fef6a25fe97bf527a25b"
            };
            var jwtSettingsOptions = Options.Create(jwtSettings);
            
            _jwtTokenService = new JwtTokenService(jwtSettingsOptions);

            _authController = new AuthenticateController(_jwtTokenService);
            

        }

        [Test]
        public void Auth_Returns_OkRequest()
        {

            var user = new UserRequest ("user","123" );

            var result = _authController.GetToken(user) as ObjectResult;

            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            Assert.That(result.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public void Auth_Returns_UnauthorizedRequest()
        {
            var user = new UserRequest("userFail", "321");

            var result = _authController.GetToken(user) as ObjectResult;

            Assert.That(result, Is.InstanceOf<UnauthorizedObjectResult>());
            Assert.That(result.StatusCode, Is.EqualTo(401));
        }
    }
}