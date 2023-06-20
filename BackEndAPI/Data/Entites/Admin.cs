using BackEndAPI.Models;

namespace BackEndAPI.Data.Entites
{
    public class Admin:User
    {
        public int CharityId { get; set; }
        public Charity Charity { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
