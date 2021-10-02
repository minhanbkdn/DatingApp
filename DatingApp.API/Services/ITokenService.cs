using DatingApp.API.Database.Entities;

namespace DatingApp.API.Services
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}