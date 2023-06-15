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

namespace BackEndAPI.Controllers
{

    public class CharityController : BaseApiController
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;


        public CharityController(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Charities
        [HttpGet]

        public async Task<ActionResult<IEnumerable<CharityDTO>>> GetAllCharities()
        {
            // retrieve all charities from the database
            var charities = await _context.Charities.All.ToListAsync();

            // map the entities to DTOs and return them
            return _mapper.Map<IEnumerable<CharityDTO>>(charities).ToList();
        }


        // GET: api/Charity/getCharity/5
        [HttpGet("getCharity/{id}")]
        public async Task<ActionResult<CharityDTO>> GetCharity(int id)
        {
            var Charity = await _context.Charities.All
                 //.Include(e => e.Charity)
                 .SingleOrDefaultAsync(e => e.Id == id);

            if (Charity == null)
            {
                return NotFound();
            }

            var charityDto = _mapper.Map<CharityDTO>(Charity);

            return charityDto;
        }


        // PUT: api/Charity/updateCharity/5
        [HttpPut("updateCharity/{id}")]
        public async Task<IActionResult> PutCharity(int id, CharityDTO charityDTO)
        {
            if (id != charityDTO.Id)
            {
                return NotFound();
            }

            var _Charity = await _context.Charities.All.SingleOrDefaultAsync(e => e.Id == id);

            if (_Charity == null)
            {
                return NotFound();
            }


            // Update charity model with values from DTO
            _mapper.Map(charityDTO, _Charity);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var _charity = await _context.Charities.FindAsyncById(id);
                if (_charity == null)
                {

                }
                if (!CharityExists(id))
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

        private bool CharityExists(int id)
        {
            throw new NotImplementedException();
        }


        // Create: api/Cases/AddNewCharities
        [HttpPost("AddNewCharity")]
        public async Task<ActionResult<CharityDTO>> CreateCharity(CharityDTO charityCreateDto)
        {
            // map the DTO to a Charity entity
            var charity = _mapper.Map<Charity>(charityCreateDto);

            // add the entity to the context and save changes
            _context.Charities.Add(charity);
            await _context.SaveChangesAsync();

            // map the entity back to a DTO and return it
            //var charityDto = _mapper.Map<CharityDTO>(charity);

            return CreatedAtAction(nameof(GetCharity), new { id = charity.Id }, charityCreateDto);
        }


        // DELETE: api/Charities/deleteCharity
        [HttpDelete("deleteCharity/{id}")]
        public async Task<ActionResult<CharityDTO>> Delete(int id)
        {
            var _Charity = await _context.Charities.All.SingleOrDefaultAsync(e => e.Id == id);

            if (_Charity == null)
            {
                return NotFound();
            }

            _context.Charities.Remove(_Charity);
            await _context.SaveChangesAsync();

            var charityDTO = _mapper.Map<CharityDTO>(_Charity);

            return Ok(charityDTO);
        }
    }
}
