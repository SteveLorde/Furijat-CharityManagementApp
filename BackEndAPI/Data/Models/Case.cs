using System.ComponentModel.DataAnnotations;
using Nest;

namespace BackEndAPI.Data.Models
{
    public class Case
    {
        [Key]
        public int CaseId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public int Totalneeded { get; set; }
        public int CharityId { get; set; }
        public Charity TheCharity { get; set; } = null!;
    }
}