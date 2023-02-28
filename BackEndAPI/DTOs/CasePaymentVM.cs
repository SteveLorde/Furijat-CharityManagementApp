using BackEndAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.Views
{
    public class CasePaymentVM
    {
        public int CasePaymentId { get; set; }

        public string PaymentMethod { get; set; }
        [Required]
        public decimal PaymentAmount { get; set; }

        public int CaseId { get; set; }
    }
}
