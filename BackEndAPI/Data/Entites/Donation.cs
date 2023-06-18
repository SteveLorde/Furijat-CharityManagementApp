using BackEndAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.Data.Entites
{

    public class Donation
    {

        public int Id { get; set; }
        public Case Case { get; set; }
        public Charity Charity { get; set; }
        public Donator Donator { get; set; }
        public decimal Amount { get; set; }
        public DateTime Time { get; set; }

        public static explicit operator Donation(List<Donation> v)
        {
            throw new NotImplementedException();
        }
    }

}
