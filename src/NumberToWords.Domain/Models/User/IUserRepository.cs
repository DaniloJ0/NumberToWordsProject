namespace NumberToWords.Domain.Models.User
{
    public interface IUserRepository
    {
        void Add(User user);
        Task<List<User>> GetAllAsync();
        Task<User> GetByIdAsync(UserId id);
    }
}
