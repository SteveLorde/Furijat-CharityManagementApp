using BackEndAPI.Data.Entites;
using BackEndAPI.Models;
using System.Collections.Generic;
using System;

namespace BackEndAPI.DTOs
{
    public class PaymentToCreditorDTO
    {
        public int CaseId { get; set; }
        public CaseDTO Case { get; set; }
        public int CharityId { get; set; }
        public CharityDTO Charity { get; set; }
        public int CreditorId { get; set; }
        public CreditorDTO Creditor { get; set; }
        public decimal Paid_Amount { get; set; }

        public DateTime Time { get; set; }

        
    }
}
