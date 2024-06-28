using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
            string numberInWords = number.ToWords(new System.Globalization.CultureInfo("es-ES"));
            if (string.IsNullOrEmpty(numberInWords))
            {
                return NotFound();
            }

            return Ok(new { number, numberInWords });
        }
        
    }
}
