using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.Models
{
    public class Case
    {
        public int CaseId { get; set; }
        [MinLength(3)]

        public string FirstName { get; set; }
        [MinLength(3)]

        public string LastName { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public string Address { get; set; }
        [Required]
        public decimal CurrentAmount { get; set; }
        [Required]

        public decimal TotalAmount { get; set; }


        public string Status { get; set; }


        public int CharityId { get; set; }


        public virtual Charity Charity { get; set; }


    }
}
