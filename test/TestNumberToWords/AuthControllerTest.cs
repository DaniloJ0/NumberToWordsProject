using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NumberToWords.API.Controllers;
using NumberToWords.API.Models;

namespace TestNumberToWords
{
    public class AuthControllerTest
    {
        private AuthenticateController _authController;

        [SetUp]
        public void Setup()
        {
            var jwtSettings = new JwtSettings
            {
                SecretKey = "2bb80d537b1da3e38bd30361aa855686bde0eacd7162fef6a25fe97bf527a25b"
            };

            var options = Options.Create(jwtSettings);
            _authController = new AuthenticateController(options);
            

        }

        [Test]
        public void Auth_Returns_OkRequest()
        {

            var user = new User { UserName = "user", Password = "123" };

            var result = _authController.GetToken(user) as ObjectResult;

            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            Assert.That(result.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public void Auth_Returns_UnauthorizedRequest()
        {
            var user = new User { UserName = "userFail", Password = "321" };

            var result = _authController.GetToken(user) as ObjectResult;

            Assert.That(result, Is.InstanceOf<UnauthorizedObjectResult>());
            Assert.That(result.StatusCode, Is.EqualTo(401));
        }
    }
}