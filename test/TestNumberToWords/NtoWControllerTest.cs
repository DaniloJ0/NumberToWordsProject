using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NumberToWords.Domain.Models.Number;
using NumberToWords.Domain.Models.Services;
using NumberToWords.Infrastructure.Services;
using NumberToWordsAPI.Controllers;

namespace TestNumberToWords
{
    public class NtoWControllerTest
    {
        private NumberToWordController _n2wController;
        private INumberToWordsService _numberToWordsService;

        [SetUp]
        public void Setup()
        {
            _numberToWordsService = new NumberToWordsService();
            _n2wController = new NumberToWordController(_numberToWordsService);

        }

        [Test]
        public void PostWordsFromNumber_Returns_OkRequest()
        {
            long numberTest = 21;
            string expectedWords = "veintiuno";

            NumberRequest numberRequest = new ()
            {
                Number = numberTest
            };

            var result = _n2wController.Call(numberRequest) as ObjectResult;
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Value, Is.Not.Null);

            var jsonResult = JsonConvert.SerializeObject(result.Value);
            var response = JsonConvert.DeserializeObject<NumberResponse>(jsonResult);

            Assert.That(response.NumberInWords, Is.EqualTo(expectedWords));
        }

        [Test]
        public void GetWordsFromNumber_Returns_OKRequest()
        {
            var result = _n2wController.Get() as ObjectResult;

            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            Assert.That(result.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public void GetWordsFromNumber_Returns_BadRequest()
        {
            NumberRequest numberRequest = new ()
            {
                Number = -1
            };
            var result = _n2wController.Call(numberRequest) as ObjectResult;
            
            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
            Assert.That(result.StatusCode, Is.EqualTo(400));    
        }
    }
}