using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NumberToWords.API.Controllers;
using NumberToWords.API.Models;
using NumberToWordsAPI.Controllers;

namespace TestNumberToWords
{
    public class NtoWControllerTest
    {
        private IConfiguration _config;
        private AuthenticateController _authController;
        private string _secrectKey;
        private NumberToWordController _n2wController;

        [SetUp]
        public void Setup()
        {
            _config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddInMemoryCollection()
                .Build();

            _secrectKey = _config["ApplicationSettings:JWT_Secret"];

            _authController = new AuthenticateController(_config);
            
            _n2wController = new NumberToWordController();

        }

        [Test]
        public void GetWordsFromNumber_Returns_OkRequest()
        {
            long numberTest = 21;
            string expectedWords = "veintiuno";

            var result = _n2wController.Get(numberTest) as ObjectResult;
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Value, Is.Not.Null);

            var jsonResult = JsonConvert.SerializeObject(result.Value);
            var response = JsonConvert.DeserializeObject<NumberResponse>(jsonResult);

            Assert.That(response.NumberInWords, Is.EqualTo(expectedWords));
        }


        [Test]
        public void GetWordsFromNumber_Returns_BadRequest()
        {
            var result = _n2wController.Get(-1) as ObjectResult;
            
            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
            Assert.That(result.StatusCode, Is.EqualTo(400));    
            
        }
    }
}