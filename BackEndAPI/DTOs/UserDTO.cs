using BackEndAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.Views
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string UType { get; set; }
        [Required(ErrorMessage = "This Filed Is Required")]
        [MinLength(6, ErrorMessage = "The MinLength 6")]
        public string Password { get; set; }
        [Required(ErrorMessage = "This Filed Is Required")]

        public string UserName { get; set; }
        [MinLength(3, ErrorMessage = "The MinLength 3")]

        public string FirstName { get; set; }
        [MinLength(3, ErrorMessage = "The MinLength 3")]

        public string LastNaame { get; set; }

        public int UserTypeID { get; set; }
        public string Token { get; set; }

   
    }

}
