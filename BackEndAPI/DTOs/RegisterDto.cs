using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.DTOs
{
    public class RegisterDTO
    {
        [Required]
        public string Username { get; set; }
        [MinLength(3, ErrorMessage = "The MinLength 3")]
        public string FirstName { get; set; }
        [MinLength(3, ErrorMessage = "The MinLength 3")]
        public string LastName { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 4)]
        public string Password { get; set; }
    }
}
