using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndAPI.Data.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string username { get; set; }
        [NotMapped]
        public string password { get; set; }
        public string passwordhash { get; set; }
        public string usertype { get; set; }
        
    }
}