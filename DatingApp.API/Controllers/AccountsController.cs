using System.Linq;
using System.Security.Cryptography;
using System.Text;
using DatingApp.API.Database;
using DatingApp.API.Database.Entities;
using DatingApp.API.DTOs;
using DatingApp.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    public class AccountsController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        public AccountsController(DataContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public ActionResult<string> Register(RegisterDto registerDto)
        {
            registerDto.Username.ToLower();
            if (_context.Users.Any(u => u.Username == registerDto.Username))
            {
                return BadRequest("Username is existed!");
            }

            using var hmac = new HMACSHA512();

            var user = new User
            {
                Username = registerDto.Username,
                Email = registerDto.Email,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok(new UserResponseDto
            {
                Username = user.Username,
                Token = _tokenService.CreateToken(user)
            });
        }

        [HttpPost("login")]
        public ActionResult<string> Login(LoginDto loginDto)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == loginDto.Username.ToLower());
            if (user == null) return Unauthorized("Invalid Username");

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (var i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid Password");
            }

            return Ok(new UserResponseDto
            {
                Username = user.Username,
                Token = _tokenService.CreateToken(user)
            });
        }
    }
}