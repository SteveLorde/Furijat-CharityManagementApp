using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.Models
{
    public class CasePayment
    {
        public int CasePaymentId { get; set; }
      
        public string PaymentMethod { get; set; }

        public decimal PaymentAmount { get; set; }

        public int CaseId { get; set; }

        public virtual Case Cases { get; set; }

    }
}
