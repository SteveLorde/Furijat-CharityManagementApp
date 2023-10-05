using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndAPI.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string username { get; set; }
        public string email { get; set; }
        [NotMapped]
        public string password { get; set; }
        public string passwordhash { get; set; }
        public string usertype { get; set; }
    }
}