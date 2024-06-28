using Microsoft.AspNetCore.Mvc;
using Humanizer;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NumberToWordsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NumberToWordController : ControllerBase
    {
        
        [HttpGet("{number}")]
        public IActionResult Get(long number)
        { 
            //long number = 21;
            var numberInWords = number.ToWords(new System.Globalization.CultureInfo("es-ES"));
            return Ok(new { number, numberInWords });
        }
    }
}
