using DatingApp.API.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}