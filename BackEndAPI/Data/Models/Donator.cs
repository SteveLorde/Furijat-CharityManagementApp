namespace BackEndAPI.Data.Models
{
    public class Donator : User
    {
        public string PaymentType { get; set; }
        public int phonenumber { get; set; }
        
    }
}