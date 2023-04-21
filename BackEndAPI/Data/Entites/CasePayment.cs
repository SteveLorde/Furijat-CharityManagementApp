using BackEndAPI.Data.Entites;
using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.Models
{
    public class CasePayment:BaseModel
    {
      
        public string PaymentMethod { get; set; }
        [Required]
        public decimal PaymentAmount { get; set; }

        public virtual Case Cases { get; set; }

    }
}
