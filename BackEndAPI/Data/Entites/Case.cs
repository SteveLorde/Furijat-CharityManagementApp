using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.Models
{
    public class Case
    {
        public int CaseId { get; set; }
        public string FirstName { get; set; }
        [MinLength(3)]
        public string LastName { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public decimal CurrentAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public virtual Charity Charity { get; set; }


    }
}
