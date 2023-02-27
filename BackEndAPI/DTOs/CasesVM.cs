using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.Views
{
    public class CasesVM
    {
        public int CasesId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }


        public string Description { get; set; }

        public string Address { get; set; }
        [Required(ErrorMessage = "This Filed Is Required")]

        public decimal CurrentAmount { get; set; }
        [Required(ErrorMessage = "This Filed Is Required")]

        public decimal TotalAmount { get; set; }


        public string Status { get; set; }


        public int CharityId { get; set; }
    }
}
