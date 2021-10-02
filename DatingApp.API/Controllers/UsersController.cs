using System.Collections.Generic;
using System.Linq;
using DatingApp.API.Database;
using DatingApp.API.Database.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return Ok(_context.Users);
        }

        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}