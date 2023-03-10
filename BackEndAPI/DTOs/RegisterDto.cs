using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 4)]
        public string Password { get; set; }
    }
}
