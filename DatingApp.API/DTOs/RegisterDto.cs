using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.DTOs
{
    public class RegisterDto
    {
        [Required]
        [StringLength(32)]
        public string Username { get; set; }

        [Required]
        [StringLength(255)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}