using BackEndAPI.Data.Entites;
using BackEndAPI.Models;
using System.Collections.Generic;
using System;

namespace BackEndAPI.DTOs
{
    public class DonationDTO
    {
        public int CaseDTOId { get; set; }
        public CaseDTO Case { get; set; }
        public int CharityDTOId { get; set; }
        public CharityDTO Charity { get; set; }
        public int DonatorDTOId { get; set; }
        public DonatorDTO Donator { get; set; }
        public decimal Amount { get; set; }
        public DateTime Time { get; set; }

        public static explicit operator DonationDTO(List<DonationDTO> v)
        {
            throw new NotImplementedException();
        }
    }
}
