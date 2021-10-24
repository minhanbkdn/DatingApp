using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DatingApp.API.Database.Entities;
using DatingApp.API.DTOs;

namespace DatingApp.API.Database.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UserRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public User GetUserByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username);
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users;
        }

        public void CreateUser(User user)
        {
            if (GetUserByUsername(user.Username) != null) return;

            _context.Users.Add(user);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public IEnumerable<MemberDto> GetMembers()
        {
            return _context.Users
                .ProjectTo<MemberDto>(_mapper.ConfigurationProvider);
        }

        public MemberDto GetMemberByUsername(string username)
        {
            return _context.Users
                .Where(u => u.Username == username)
                .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
        }

        public void UpdateProfile(string username, ProfileDto profile)
        {
            var user = GetUserByUsername(username);
            if (user == null) return;
            _mapper.Map(profile, user);
        }
    }
}