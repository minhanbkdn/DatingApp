using System.Collections.Generic;
using DatingApp.DatingApp.API.Database;
using DatingApp.DatingApp.API.Database.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return _context.Users;
        }
    }
}