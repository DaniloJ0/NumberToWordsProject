using Microsoft.EntityFrameworkCore;
using NumberToWords.Domain.Models.User;

namespace ContactManagement.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add (User user) => _context.Users.Add(user);

        public async Task<List<User>> GetAllAsync() => await _context.Users.ToListAsync();  

        public async Task<User?> GetByIdAsync(UserId id) => await _context.Users.FindAsync(id);
    }
}
