using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndAPI.Data.Entites
{
    public class CharityManagment
    {
        public int CreditorID { get; set; }

        public int CharityID { get; set; }
     
        public int CaseID { get; set; }
        public int Deserves_Debt { get; set; }
        public int PaidAmount { get; set; }
        public DateTime PaymentDate { get; set; }


    }
}
