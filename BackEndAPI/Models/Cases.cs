namespace BackEndAPI.Models
{
    public class Cases
    {
        public int CasesId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }


        public string Description { get; set; }

        public string Address { get; set; }

        public decimal CurrentAmount { get; set; }
        public decimal TotalAmount { get; set; }


        public string Status { get; set; }


        public int CharityId { get; set; }


        public virtual Charity Charity { get; set; }


    }
}
