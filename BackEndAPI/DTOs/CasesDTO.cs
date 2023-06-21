using BackEndAPI.Models;
using BackEndAPI.Views;
using BackEndAPI.Data.Entites;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndAPI.DTOs
{
    public class CaseDTO : UserDTO
    {
        public string Phone { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public decimal TotalAmount { get; set; }
        public string MarriageStatus { get; set; }
        public string? Status { get; set; }
        //public ICollection<CharityDTO> Charities {get; set;}
        //public virtual ICollection<Donation> Donation {get; set;}
        public virtual ICollection<DonationDTO> Donation { get; set; }
        public virtual ICollection<PaymentToCreditorDTO> PaymentToCreditor { get; set; }
    }
}


