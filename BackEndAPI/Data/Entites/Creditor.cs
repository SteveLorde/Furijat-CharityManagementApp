using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndAPI.Data.Entites
{
    public class Creditor
    {
        public int CreditorID { get; set; }

        public int CaseID { get; set; }

        [MaxLength(11)]
        public string Phone { get; set; }
        public string Description { get; set; }
        public string Payment_Account { get; set; }

        public string Address { get; set; }
        public decimal Deserves_Amount { get; set; }

        public virtual ICollection<CharityManagment> CharityManagment { get; set; }
        public virtual ICollection<CreditorCases> CreditorCases { get; set; }


    }
}
