using BackEndAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.Views
{
    public class UserVM
    {
        public int UserId { get; set; }
        public string UType { get; set; }
        [Required(ErrorMessage = "This Filed Is Required")]
        [MinLength(6, ErrorMessage = "The MinLength 6")]
        public string Password { get; set; }
        [Required(ErrorMessage = "This Filed Is Required")]

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastNaame { get; set; }

        public int UserTypeID { get; set; }

   
    }

}
