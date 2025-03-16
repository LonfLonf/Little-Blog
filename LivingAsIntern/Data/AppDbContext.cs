using LivingAsIntern.Entities;
using Microsoft.EntityFrameworkCore;

namespace LivingAsIntern.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Post> posts { get; set; }
        public DbSet<User> users { get; set; }
    }
}
