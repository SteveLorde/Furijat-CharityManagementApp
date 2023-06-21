using BackEndAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.Data.Entites
{
    public class Donator : User
    {
        [MaxLength(11)]
        public string Phone { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Address { get; set; }
        public decimal PaidAmount { get; set; }
        public string Status { get; set; }
        public virtual ICollection<Donation> Donation { get; set; }
        public virtual ICollection<PaymentToCreditor> PaymentToCreditor { get; set; }
        public static implicit operator Donator(int v)
        {
            throw new NotImplementedException();
        }
    }
}
