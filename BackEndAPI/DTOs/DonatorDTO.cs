using BackEndAPI.Data.Entites;
using BackEndAPI.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.DTOs
{
    public class DonatorDTO
    {
        
            public int Id { get; set; }
            public string Phone { get; set; }
            public string Address { get; set; }
            public decimal PaidAmount { get; set; }
            public string Status { get; set; }
            public virtual ICollection<CharityDonators> CharityDonators { get; set; }

        }
    }


