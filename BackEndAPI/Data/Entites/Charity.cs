using BackEndAPI.Data.Entites;
using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.Models
{
    public class Charity:BaseModel
    {
        [MinLength(3)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }

        public string Location { get; set; }

        public string Phone { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        public virtual User User { get; set; }

    }
}
