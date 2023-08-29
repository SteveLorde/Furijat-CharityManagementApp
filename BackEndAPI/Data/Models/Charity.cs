namespace BackEndAPI.Data.Models
{
    public class Charity
    {
        public int Id { get; set; }
        public string charityname { get; set; }
        public int phonenumber { get; set; }
        public ICollection<Case> Cases { get; } = new List<Case>();
    }
    
}
