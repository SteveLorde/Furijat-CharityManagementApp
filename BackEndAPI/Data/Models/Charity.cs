namespace BackEndAPI.Data.Models
{
    public class Charity : User
    {
        public int CharityId { get; set; }
        public string charityname { get; set; }
        public int phonenumber { get; set; }
        
    }
}