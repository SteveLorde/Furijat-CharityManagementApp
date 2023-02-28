using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.Views
{
    public class CasesVM
    {
        public int CasesId { get; set; }
        [MinLength(3, ErrorMessage = "The MinLength 3")]

        public string FirstName { get; set; }
        [MinLength(3, ErrorMessage = "The MinLength 3")]

        public string LastName { get; set; }

        [MaxLength(200,ErrorMessage ="The MaxLength Is 200")]

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
