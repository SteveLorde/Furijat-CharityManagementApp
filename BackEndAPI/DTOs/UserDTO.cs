using BackEndAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.Views
{
    public class UserDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This Filed Is Required")]
        public string UserName { get; set; }
        [MinLength(3, ErrorMessage = "The MinLength 3")]
        public string FirstName { get; set; }
        [MinLength(3, ErrorMessage = "The MinLength 3")]
        public string LastName { get; set; }
        public string UType { get; set; }
        public string Token { get; set; }
        public int CharityId { get; set; }
    }

}
