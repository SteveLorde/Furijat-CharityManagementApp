using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.Models
{
    public class User
    {
        public int UserId { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        [Required]

        public string UserName { get; set; }
        [MinLength(3)]

        public string FirstName { get; set; }
        [MinLength(3)]

        public string LastNaame { get; set; }

        public int UserTypeID { get; set; }

        public virtual UserType UserType { get; set; }
    }
}
