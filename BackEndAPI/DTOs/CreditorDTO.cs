using BackEndAPI.Data.Entites;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.DTOs
{
    public class CreditorDTO
    {
        public int Id { get; set; }
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
