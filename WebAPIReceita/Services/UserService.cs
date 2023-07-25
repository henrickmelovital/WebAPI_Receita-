using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPIReceita.Context;
using WebAPIReceita.Models;

namespace WebAPIReceita.Services
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
        Task<bool> RegisterUser(User user);
    }

    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> Authenticate(string username, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
        }

        public async Task<bool> RegisterUser(User user)
        {
            try
            {
                // Verificar se o nome de usuário já existe no banco de dados
                var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Username == user.Username);
                if (existingUser != null)
                {
                    return false; // Nome de usuário já está em uso
                }

                // Criar uma instância do usuário com os dados fornecidos
                var newUser = new User
                {
                    Username = user.Username,
                    Password = user.Password 
                };

                
                _context.Users.Add(newUser);
                await _context.SaveChangesAsync();

                return true; 
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
