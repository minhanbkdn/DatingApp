namespace DatingApp.API.Database.Entities
{
    public class UserLike
    {
        public int SourceUserId { get; set; }

        public int LikedUserId { get; set; }

        public virtual User SourceUser { get; set; }

        public virtual User LikedUser { get; set; }
    }
}