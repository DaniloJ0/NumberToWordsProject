namespace NumberToWords.Domain.Models.User
{
    public class User
    {
        public User() { }
        public User(string UserName, string Password)
        {
            //this.Id = Id;
            this.UserName = UserName;
            this.Password = Password;
        }
        public UserId Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
