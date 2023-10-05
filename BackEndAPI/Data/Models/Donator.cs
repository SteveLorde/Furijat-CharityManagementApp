using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndAPI.Data.Models
{
    public class Donator : User
    {
        public int DonatorId { get; set; }
        public string paymenttype { get; set; }
        public int phonenumber { get; set; }
        //donation logging
        public ICollection<Case> DonatedCase { get; set; }
    }
}