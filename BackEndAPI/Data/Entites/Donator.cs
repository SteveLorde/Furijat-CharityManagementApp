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
        public string Address { get; set; }
        public decimal PaidAmount { get; set; }
<<<<<<< HEAD
        public string Status { get; set; }

=======
        public string? Status { get; set; }
        public virtual ICollection<Donation> Donation { get; set; }
        public virtual ICollection<PaymentToCreditor> PaymentToCreditor { get; set; }
>>>>>>> 5943e17344768e6da77ca16bfbf592486bb02e21
        public static implicit operator Donator(int v)
        {
            throw new NotImplementedException();
        }
    }
}
