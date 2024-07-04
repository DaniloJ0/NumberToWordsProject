using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NumberToWords.API.Models;

namespace NumberToWordsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class NumberToWordController : ControllerBase
    {

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            return Ok("Welcome to NumberToWords API");
        }

        [HttpPost]
        public IActionResult Call(NumberRequest numberRequest)
        { 
            if (numberRequest is null)
                return BadRequest("Number is required");

            if (numberRequest.Number < 0 || numberRequest.Number > 999999999999)
                return BadRequest("Values must be from 0 to 999999999999");

            string numberInWords = numberRequest.Number.ToWords(new System.Globalization.CultureInfo("es-ES"));
            
            if (string.IsNullOrEmpty(numberInWords))
                return NotFound();

            var response = new NumberResponse
            {
                Number = numberRequest.Number,
                NumberInWords = numberInWords
            };

            return Ok(response);
        }
    }
}
