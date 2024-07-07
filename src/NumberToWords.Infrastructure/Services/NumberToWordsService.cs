using NumberToWords.Domain.Models.Services;
using Humanizer;

namespace NumberToWords.Infrastructure.Services
{
    public class NumberToWordsService : INumberToWordsService
    {
        public string NumberToWords(long number)
        {
            return number.ToWords(new System.Globalization.CultureInfo("es-ES"));
        }
    }
}
