using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Nest;

namespace BackEndAPI.Data.Models
{
    public class Case : User
    {
        public int CaseId { get; set; }
        public string Name { get; set; }
        public string description { get; set; }
        public string Address { get; set; }
        public int currentdonations { get; set;}
        public int Totalneeded { get; set; }
        public string Status { get; set; }
        public int CharityId { get; set; }
        public Charity Charity { get; set; }
    }
}