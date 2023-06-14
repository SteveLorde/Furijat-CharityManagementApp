using System;

namespace BackEndAPI.Data.Entites
{
    public class CharityDonators
    {
        public int CharityID { get; set; }
        public int DonatorID { get; set; }

        public decimal PaidAmount { get; set; }
        public DateTime PaymentDate { get; set; }

    }
}
