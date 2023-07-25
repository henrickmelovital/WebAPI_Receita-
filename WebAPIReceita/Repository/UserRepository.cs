using System.Threading.Tasks;
using WebAPIReceita.Context;
using WebAPIReceita.Models;
using Microsoft.EntityFrameworkCore;


namespace WebAPIReceita.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByUsername(string username);
    }

    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}
