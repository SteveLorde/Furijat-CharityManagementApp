using AutoMapper;
using BackEndAPI.DTOs;
using BackEndAPI.Models;
using BackEndAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndAPI.Data.Interfaces;
using BackEndAPI.Interfaces;
using Nest;
using System.Linq.Expressions;
using System;
using System.Security.Policy;
using BackEndAPI.Data.Entites;


namespace BackEndAPI.Controllers
{

    public class DonatorController : BaseApiController
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;


        public DonatorController(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Donators
        [HttpGet]

        public async Task<ActionResult<IEnumerable<DonatorDTO>>> GetAllDonators()
        {
            // retrieve all donators from the database
            var donators = await _context.Donators.All.ToListAsync();

            // map the entities to DTOs and return them
            return _mapper.Map<IEnumerable<DonatorDTO>>(donators).ToList();
        }


        // GET: api/Donators/getDonator/5
        [HttpGet("getDonator/{id}")]
        public async Task<ActionResult<DonatorDTO>> GetDonator(int id)
        {
            var Donator = await _context.Donators.All
                 //.Include(e => e.Donator)
                 .SingleOrDefaultAsync(e => e.Id == id);

            if (Donator == null)
            {
                return NotFound();
            }

            var DonatorDto = _mapper.Map<DonatorDTO>(Donator);

            return DonatorDto;
        }


        // PUT: api/Donator/updateDonator/5
        [HttpPut("updateDonator/{id}")]
        public async Task<IActionResult> PutCharity(int id, DonatorDTO donatorDTO)
        {
            if (id != donatorDTO.Id)
            {
                return NotFound();
            }

            var _Donator = await _context.Donators.All.SingleOrDefaultAsync(e => e.Id == id);

            if (_Donator == null)
            {
                return NotFound();
            }


            // Update charity model with values from DTO
            _mapper.Map(donatorDTO, _Donator);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var _donator = await _context.Donators.FindAsyncById(id);
                if (_donator == null)
                {

                }
                if (!DonatorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool DonatorExists(int id)
        {
            throw new NotImplementedException();
        }


        // Create: api/Donators/AddNewDonators
        [HttpPost("AddNewDonator")]
        public async Task<ActionResult<DonatorDTO>> CreateDonator(CharityDTO donatorCreateDto)
        {
            // map the DTO to a Donator entity
            var donator = _mapper.Map<Donator>(donatorCreateDto);

            // add the entity to the context and save changes
            _context.Donators.Add(donator);
            await _context.SaveChangesAsync();

            // map the entity back to a DTO and return it
            //var donatorDto = _mapper.Map<DonatorDTO>(donator);

            return CreatedAtAction(nameof(GetDonator), new { id = donator.Id }, donatorCreateDto);
        }


        // DELETE: api/Donators/deleteDonator
        [HttpDelete("deleteDonator/{id}")]
        public async Task<ActionResult<DonatorDTO>> Delete(int id)
        {
            var _Donator = await _context.Donators.All.SingleOrDefaultAsync(e => e.Id == id);

            if (_Donator == null)
            {
                return NotFound();
            }

            _context.Donators.Remove(_Donator);
            await _context.SaveChangesAsync();

            var DonatorDTO = _mapper.Map<DonatorDTO>(_Donator);

            return Ok(DonatorDTO);
        }
    }
}
