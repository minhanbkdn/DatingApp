using System.Linq;
using DatingApp.API.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Database.Repositories
{
    public class UserLikeRepository : IUserLikeRepository
    {
        private readonly DataContext _context;
        public UserLikeRepository(DataContext context)
        {
            _context = context;
        }
        public bool LikeUser(string sourceUsername, string likedUsername)
        {
            var sourceUser = _context.Users
                .Include(x => x.SourceUsers)
                .FirstOrDefault(u => u.Username == sourceUsername);
            if (sourceUser == null) return false;
            var likedUser = _context.Users.FirstOrDefault(u => u.Username == likedUsername);
            if (likedUser == null) return false;
            if (sourceUser.SourceUsers.Any(u => u.LikedUserId == likedUser.Id)) return false;
            _context.UserLikes.Add(new UserLike
            {
                LikedUserId = likedUser.Id,
                SourceUserId = sourceUser.Id
            });
            return _context.SaveChanges() > 0;
        }
    }
}