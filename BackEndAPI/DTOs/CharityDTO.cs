﻿using BackEndAPI.Models;
using BackEndAPI.Views;
using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.DTOs
{
    public class CharityDTO
    {
        public int Id { get; set; }
        [MinLength(3)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }

        public string Location { get; set; }

        public string Phone { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        public UserDTO User { get; set; }
    }
}