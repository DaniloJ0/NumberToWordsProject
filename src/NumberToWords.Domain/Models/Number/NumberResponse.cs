namespace NumberToWords.Domain.Models.Number
{
    public class NumberResponse
    {
        public long Number { get; set; }
        public string NumberInWords { get; set; } = string.Empty;
    }
}
