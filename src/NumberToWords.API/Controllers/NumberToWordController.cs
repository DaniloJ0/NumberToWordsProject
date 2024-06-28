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
        
        [HttpGet("{number}")]
        public IActionResult Get(long number)
        { 
            if (number < 0 || number > 999999999999)
                return BadRequest("Values must be from 0 to 999999999999");

            string numberInWords = number.ToWords(new System.Globalization.CultureInfo("es-ES"));
            
            if (string.IsNullOrEmpty(numberInWords))
                return NotFound();

            var response = new NumberResponse
            {
                Number = number,
                NumberInWords = numberInWords
            };

            return Ok(response);
        }
        
    }
}
