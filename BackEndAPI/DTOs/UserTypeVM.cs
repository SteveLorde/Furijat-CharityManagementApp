using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.Views
{
    public class UserTypeVM
    {
        public int UserTypeId { get; set; }
        [Required(ErrorMessage = "This Filed Is Required")]

        public string Name { get; set; }
    }
}
