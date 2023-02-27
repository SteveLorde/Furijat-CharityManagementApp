namespace BackEndAPI.Models
{
    public class Charity
    {
        public int CharityId { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public int UserID { get; set; }


        public virtual User User { get; set; }

    }
}
