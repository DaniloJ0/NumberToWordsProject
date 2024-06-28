using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NumberToWords.API.Controllers;
using NumberToWords.API.Models;
using NumberToWordsAPI.Controllers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestNumberToWords
{
    public class AuthControllerTest
    {
        private IConfiguration _config;
        private AuthenticateController _authController;

        [SetUp]
        public void Setup()
        {
            _config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddInMemoryCollection()
                .Build();

            _authController = new AuthenticateController(_config);
            

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