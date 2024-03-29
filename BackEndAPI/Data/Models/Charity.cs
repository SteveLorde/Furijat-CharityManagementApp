using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndAPI.Data.Models
{
    public class Charity : User
    {
        public int CharityId { get; set; }
        public string charityname { get; set; }
        public string description { get; set; }
        public int phonenumber { get; set; }
        public ICollection<Case> Cases { get; set; }
    }
    
}
