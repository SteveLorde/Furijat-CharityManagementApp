using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.Views
{
    public class CharityVM
    {
        public int CharityId { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public string Phone { get; set; }
         [EmailAddress(ErrorMessage = "Invalid Mail ")]
        [Required(ErrorMessage = "This Filed Is Required")]
        public string Email { get; set; }

        public int UserID { get; set; }
    }
}
