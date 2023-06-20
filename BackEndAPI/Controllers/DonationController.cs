using AutoMapper;
using BackEndAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndAPI.Data.Interfaces;
using BackEndAPI.Data.Entites;
using Microsoft.AspNetCore.Authorization;
using BackEndAPI.Models;
using BackEndAPI.Database;
using System;

namespace BackEndAPI.Controllers
{
    //[Authorize]
    public class DonationController : BaseApiController
    {
        //private readonly IAppDbContext _context;
        private readonly FurijatContext _context;
        private readonly IMapper _mapper;


        public DonationController(FurijatContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        
        [HttpGet]
        public ActionResult GetDonations()
        {
            try
            {
                var donations = _context.Donation;
                return Ok(donations);
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }

        [HttpGet("getdonationfordonator/{id}")]
        public IActionResult GetDonationsByDonatorID(string id)
        {
            try
            {
                Donation donations = (Donation)_context.Donation.Where(e => e.Donator.Id == int.Parse(id)).ToList();
                return Ok(donations);
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }
        
        [HttpGet("getdonationforcharity/{id}")]
        public IActionResult GetDonationsByCharityID(string id)
        {
            try
            {
                Donation donations = (Donation)_context.Donation.Where(e => e.Charity.Id == int.Parse(id)).ToList();
                return Ok(donations);
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }

        [HttpPost("AddDonation")]
        public IActionResult AddDonation(Donation donation)
        {
            try
            {
                _context.Donation.Add(donation);
                return Ok("Donation Recorded");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound("Something Unexpected Happened");
            }
        }
    }
}
