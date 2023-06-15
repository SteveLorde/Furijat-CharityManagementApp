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

    public class CreditorController : BaseApiController
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;


        public CreditorController(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Creditors
        [HttpGet]

        public async Task<ActionResult<IEnumerable<CreditorDTO>>> GetAllCreditors()
        {
            // retrieve all creditors from the database
            var Creditors = await _context.Creditors.All.ToListAsync();

            // map the entities to DTOs and return them
            return _mapper.Map<IEnumerable<CreditorDTO>>(Creditors).ToList();
        }


        // GET: api/Creditor/getCreditor/5
        [HttpGet("getCreditor/{id}")]
        public async Task<ActionResult<CreditorDTO>> GetCreditor(int id)
        {
            var Creditor = await _context.Creditors.All
                 //.Include(e => e.Creditor)
                 .SingleOrDefaultAsync(e => e.Id == id);

            if (Creditor == null)
            {
                return NotFound();
            }

            var creditorDto = _mapper.Map<CreditorDTO>(Creditor);

            return creditorDto;
        }


        // PUT: api/Creditor/updateCreditor/5
        [HttpPut("updateCreditor/{id}")]
        public async Task<IActionResult> PutCreditor(int id, CreditorDTO creditorDTO)
        {
            if (id != creditorDTO.Id)
            {
                return NotFound();
            }

            var _Creditor = await _context.Creditors.All.SingleOrDefaultAsync(e => e.Id == id);

            if (_Creditor == null)
            {
                return NotFound();
            }


            // Update creditor model with values from DTO
            _mapper.Map(creditorDTO, _Creditor);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var _creditor = await _context.Creditors.FindAsyncById(id);
                if (_creditor == null)
                {

                }
                if (!CreditorExists(id))
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

        private bool CreditorExists(int id)
        {
            throw new NotImplementedException();
        }


        // Create: api/Creditors/AddNewCreditors
        [HttpPost("AddNewCreditor")]
        public async Task<ActionResult<CreditorDTO>> CreateCreditor(CreditorDTO creditorCreateDto)
        {
            // map the DTO to a Creditor entity
            var creditor = _mapper.Map<Creditor>(creditorCreateDto);

            // add the entity to the context and save changes
            _context.Creditors.Add(creditor);
            await _context.SaveChangesAsync();

            // map the entity back to a DTO and return it
            //var creditorDto = _mapper.Map<CreditorDTO>(creditor);

            return CreatedAtAction(nameof(GetCreditor), new { id = creditor.Id }, creditorCreateDto);
        }


        // DELETE: api/Creditorss/deleteCreditor
        [HttpDelete("deleteCreditor/{id}")]
        public async Task<ActionResult<CreditorDTO>> Delete(int id)
        {
            var _Creditor = await _context.Creditors.All.SingleOrDefaultAsync(e => e.Id == id);

            if (_Creditor == null)
            {
                return NotFound();
            }

            _context.Creditors.Remove(_Creditor);
            await _context.SaveChangesAsync();

            var creditorDTO = _mapper.Map<CreditorDTO>(_Creditor);

            return Ok(creditorDTO);
        }
    }
}
