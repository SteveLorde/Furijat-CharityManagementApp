using BackEndAPI.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.Data.Entites
{
    public class Donator:User
    {
        [MaxLength(11)]
        public string Phone { get; set; }
        public string Address { get; set; }
        public decimal PaidAmount { get; set; }
        public string Status { get; set; }
    }
}
