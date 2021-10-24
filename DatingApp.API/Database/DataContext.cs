using DatingApp.API.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<UserLike> UserLikes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserLike>()
                .HasKey(k => new { k.LikedUserId, k.SourceUserId });

            builder.Entity<UserLike>()
                .HasOne(s => s.SourceUser)
                .WithMany(s => s.SourceUsers)
                .HasForeignKey(k => k.SourceUserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<UserLike>()
                .HasOne(s => s.LikedUser)
                .WithMany(s => s.LikedUsers)
                .HasForeignKey(k => k.LikedUserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}