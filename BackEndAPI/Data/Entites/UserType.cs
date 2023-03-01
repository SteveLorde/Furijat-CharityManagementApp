using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.Models
{
    public class UserType
    {
        public int UserTypeId { get; set; }
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
    }
}
