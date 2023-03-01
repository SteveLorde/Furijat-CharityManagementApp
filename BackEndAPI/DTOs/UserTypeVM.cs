using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.Views
{
    public class UserTypeVM
    {
        public int UserTypeId { get; set; }
        [Required(ErrorMessage = "This Filed Is Required")]
        [MinLength(3)]
        public string Name { get; set; }
    }
}
