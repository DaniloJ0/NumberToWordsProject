namespace NumberToWords.API.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public User() { }

        public User(string UserName, string Password)
        {
            this.UserName = UserName;
            this.Password = Password;
        }
    }
}
