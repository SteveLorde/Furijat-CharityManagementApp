﻿using BackEndAPI.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.Data.Entites
{

    public class Case : User
    {
        [MaxLength(11)]
        public string Phone { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public decimal TotalAmount { get; set; }
        public string MarriageStatus { get; set; }
    }

}
