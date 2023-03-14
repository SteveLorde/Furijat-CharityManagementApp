using BackEndAPI.Data.Entites;
using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.Models
{
    public class UserType:BaseModel
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
    }
}
