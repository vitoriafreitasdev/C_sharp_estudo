using API_PIMV.Models;
using Microsoft.EntityFrameworkCore;

namespace API_PIMV.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Users> Users => Set<Users>();
        public DbSet<Events> Events => Set<Events>();
        public DbSet<Comments> Comments => Set<Comments>();
        public DbSet<RegisteredUsersInEvents> RegisteredUsersInEvents => Set<RegisteredUsersInEvents>();


    }
}
