using BackEndAPI.Models;
using BackEndAPI.Views;
using BackEndAPI.Data.Entites;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndAPI.DTOs
{
    public class CasesDTO
    {
            public int Id { get; set; }
            public string Phone { get; set; }
            public string Description { get; set; }
            public string Address { get; set; }
            public decimal TotalAmount { get; set; }
            public string MarriageStatus { get; set; }
            
        }
    }


