using BackEndAPI.Models;
using System;

namespace BackEndAPI.Data.Entites
{
    public class PaymentToCreditor
    {
        public int CaseId { get; set; }
        public Case Case { get; set; }
        public int CharityId { get; set; }
        public Charity Charity { get; set; }
        public int CreditorId { get; set; }
        public Creditor Creditor { get; set; }
        public decimal Paid_Amount { get; set; }
        public decimal Deserves_Debt { get; set; }
        public DateTime Time { get; set; }

    }
}
