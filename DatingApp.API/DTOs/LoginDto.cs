using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.DTOs
{
    public class LoginDto
    {
        [Required]
        [StringLength(32)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}