using BackEndAPI.Data.Entites;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndAPI.Models
{
    public class Charity:BaseModel
    {
        [MinLength(3)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        public string Bank_Account { get; set; }


        public string Location { get; set; }

        public string Phone { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        public string Website { get; set; }

        public Admin Admin { get; set; }
        [ForeignKey("Id")]
        public int AdminID { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<CharityManagment> CharityManagment { get; set; }
        public virtual ICollection<CharityDonators> CharityDonators { get; set; }

    }
}
