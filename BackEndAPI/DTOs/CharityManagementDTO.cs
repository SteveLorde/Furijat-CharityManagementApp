using System;

namespace BackEndAPI.DTOs
{
    public class CharityManagementDTO
    {
        public int CharityID { get; set; }
        public int CaseID { get; set; }

        public decimal DeservesDebt { get; set; }

        public decimal PaidAmount { get; set; }

        public DateTime PaymentDate { get; set; }
    }
}
