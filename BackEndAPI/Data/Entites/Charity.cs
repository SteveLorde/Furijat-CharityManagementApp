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

        public string? Status { get; set; }
        public int AdminId { get; set; }
        public Admin Admin { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        [Required]

        public string UserName { get; set; }
        public virtual ICollection<Case> Cases { get; set; }
        public virtual ICollection<Donation> Donation { get; set; }
        public virtual ICollection<PaymentToCreditor> PaymentToCreditor { get; set; }

    }
}
