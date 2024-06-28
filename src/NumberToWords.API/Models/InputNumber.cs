namespace NumberToWordsAPI.Models
{
    public class InputNumber
    {
        InputNumber() { }

        InputNumber(long Number) 
        {
            this.Number = Number;
        }
        public long Number { get; set; }
    }
}
