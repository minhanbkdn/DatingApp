using System.Collections.Generic;
using System.Security.Claims;
using DatingApp.API.Database.Repositories;
using DatingApp.API.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{

    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserLikeRepository _userLikeRepository;
        public UsersController(IUserRepository userRepository, IUserLikeRepository userLikeRepository)
        {
            _userLikeRepository = userLikeRepository;
            _userRepository = userRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MemberDto>> Get()
        {
            return Ok(_userRepository.GetMembers());
        }

        [HttpGet("{username}")]
        public ActionResult<MemberDto> Get(string username)
        {
            var member = _userRepository.GetMemberByUsername(username);
            if (member == null)
            {
                return NotFound();
            }
            return Ok(member);
        }

        [HttpPut]
        public ActionResult Put(ProfileDto profileDto)
        {
            var username = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (string.IsNullOrEmpty(username)) return NotFound();
            _userRepository.UpdateProfile(username, profileDto);
            if (_userRepository.SaveChanges()) return NoContent();
            return BadRequest();
        }

        [HttpPost("{likedUsername}")]
        public ActionResult Like(string likedUsername)
        {
            var sourceUsername = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (_userLikeRepository.LikeUser(sourceUsername, likedUsername)) return NoContent();
            return BadRequest();
        }
    }
}