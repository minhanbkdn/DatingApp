namespace DatingApp.API.Database.Repositories
{
    public interface IUserLikeRepository
    {
        bool LikeUser(string sourceUsername, string likedUsername);
    }
}