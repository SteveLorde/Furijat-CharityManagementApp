using Nest;

namespace BackEndAPI.Data.Models
{
    public class Case
    {
        public string Status { get; set; }
        public string Name { get; set; }
        public int Totalneeded { get; set; }
    }
}