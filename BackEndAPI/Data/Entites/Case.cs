using BackEndAPI.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.Data.Entites
{

    public class Case : User
    {
        [MaxLength(11)]

        public string Phone { get; set; }
        public int CharityId { get; set; }
        public Charity Charity { get; set; }
        //public int UserId { get; set; }
        //public User User { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
      //  public decimal CurrentAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public string MarriageStatus { get; set; }
      
        public virtual ICollection<Donation> Donation { get; set; }
        public virtual ICollection<PaymentToCreditor> PaymentToCreditor { get; set; }
    }

}
