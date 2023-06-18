using BackEndAPI.Data.Entites;
using BackEndAPI.Models;
using BackEndAPI.Views;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndAPI.DTOs
{
    public class CharityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Bank_Account { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string? Status { get; set; }
        public virtual ICollection<UserDTO> Users { get; set; }
        public virtual ICollection<CaseDTO> Cases { get; set; }
        //public virtual ICollection<Dona> Donation { get; set; }

    }
}
