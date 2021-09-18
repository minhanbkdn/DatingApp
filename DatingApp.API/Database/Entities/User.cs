using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.Database.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(32)]
        public string Username { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }
    }
}