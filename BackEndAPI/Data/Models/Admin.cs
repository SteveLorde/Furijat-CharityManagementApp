using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndAPI.Data.Models
{
    public class Admin : User
    {
        public int AdminId { get; set; }
    }
}