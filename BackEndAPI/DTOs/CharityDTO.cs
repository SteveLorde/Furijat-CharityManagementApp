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
        [MaxLength(200)]
        public string Description { get; set; }
        public string Bank_Account { get; set; }


        public string Location { get; set; }

        public string Phone { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        public string Website { get; set; }

        public Admin Admin { get; set; }
        [ForeignKey("AdminID")]
        public int AdminID { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<CharityManagment> CharityManagment { get; set; }
        public virtual ICollection<CharityDonators> CharityDonators { get; set; }
    }
}
