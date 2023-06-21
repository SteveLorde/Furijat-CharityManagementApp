using BackEndAPI.Data.Entites;
using BackEndAPI.Models;
using BackEndAPI.Views;
using System.Collections.Generic;

namespace BackEndAPI.DTOs
{
    public class DonatorDTO:UserDTO
    {
        public int UserId { get; set; }
        public UserDTO User { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public decimal PaidAmount { get; set; }
        public string Status { get; set; }
        public virtual ICollection<DonationDTO> Donation { get; set; }
        public virtual ICollection<PaymentToCreditorDTO> PaymentToCreditor { get; set; }
    }
}


