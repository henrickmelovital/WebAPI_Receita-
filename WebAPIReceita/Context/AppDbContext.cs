using Microsoft.EntityFrameworkCore;
using WebAPIReceita.Models;

namespace WebAPIReceita.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
    }
}
