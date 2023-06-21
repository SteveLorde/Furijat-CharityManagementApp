using BackEndAPI.Data.Entites;
using BackEndAPI.Models;
using System.Collections.Generic;
using System;

namespace BackEndAPI.DTOs
{
    public class DonationDTO
    {
        public int CaseId { get; set; }
        public CaseDTO Case { get; set; }
        public int CharityId { get; set; }
        public CharityDTO Charity { get; set; }
        public int DonatorId { get; set; }
        public DonatorDTO Donator { get; set; }
        public decimal Amount { get; set; }
        public DateTime Time { get; set; }

        public static explicit operator DonationDTO(List<DonationDTO> v)
        {
            throw new NotImplementedException();
        }
    }
}
