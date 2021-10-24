using System.Collections.Generic;
using DatingApp.API.Database.Entities;
using DatingApp.API.DTOs;

namespace DatingApp.API.Database.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetUserByUsername(string username);
        User GetUserById(int id);
        void CreateUser(User user);
        bool SaveChanges();
        IEnumerable<MemberDto> GetMembers();
        MemberDto GetMemberByUsername(string username);
        void UpdateProfile(string username, ProfileDto profile);
    }
}