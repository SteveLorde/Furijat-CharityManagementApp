using BackEndAPI.Views;

namespace BackEndAPI.DTOs
{
    public class DonatorDTO:UserDTO
    {
        public string Phone { get; set; }
        public string Address { get; set; }

        public decimal PaidAmount { get; set; }

        public string Status { get; set; }

    }
}


