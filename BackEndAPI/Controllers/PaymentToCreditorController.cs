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
    public class PaymentToCreditorController : BaseApiController
    {
        //private readonly IAppDbContext _context;
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;


        public PaymentToCreditorController(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult GetPaymentToCreditor()
        {
            try
            {
                var PaymentToCreditor = _context.PaymentToCreditor.All;
                return Ok(PaymentToCreditor);
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }

        [HttpGet("getPaymentforCreditor/{id}")]
        public IActionResult GetPaymentByCreditorID(string id)
        {
            try
            {
                PaymentToCreditor PaymentToCreditor = _context.PaymentToCreditor.All.SingleOrDefault(e => e.Charity.Id == int.Parse(id));
                return Ok(PaymentToCreditor);
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }

        [HttpGet("getPaymentToCreditor/{id}")]
        public IActionResult GetPaymentByCharityID(string id)
        {
            try
            {
                PaymentToCreditor PaymentToCreditor = _context.PaymentToCreditor.All.SingleOrDefault(e => e.Charity.Id == int.Parse(id));
                return Ok(PaymentToCreditor);
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }

        [HttpPost("AddPaymentToCreditor")]
        public async Task<IActionResult> AddPaymentToCreditor(PaymentToCreditor PaymentToCreditor)
        {
            try
            {
                _context.PaymentToCreditor.Add(PaymentToCreditor);
                await _context.SaveChangesAsync();
                return Ok("PaymentToCreditor Recorded");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound("Something Unexpected Happened");
            }
        }
    }
}

