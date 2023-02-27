namespace BackEndAPI.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UType { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastNaame { get; set; }

        public int UserTypeID { get; set; }

        public virtual UserType UserType { get; set; }
    }
}
