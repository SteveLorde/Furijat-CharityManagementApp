using AutoMapper;
using BackEndAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndAPI.Data.Interfaces;
using System;
using BackEndAPI.Data.Entites;
using Microsoft.AspNetCore.Authorization;
using BackEndAPI.Models;

namespace BackEndAPI.Controllers
{
    //[Authorize]
    public class CasesController : BaseApiController
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;


        public CasesController(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Cases
        [HttpGet]

        public async Task<ActionResult<IEnumerable<CaseDTO>>> GetAllCases()
        {
            // retrieve all cases from the database
            var cases = await _context.Cases.All.ToListAsync();

            if(cases.Any())
                return _mapper.Map<IEnumerable<CaseDTO>>(cases).ToList();
            else 
                return new List<CaseDTO>();
        }


        // GET: api/Case/getCase/5
        [HttpGet("getCase/{id}")]
        public async Task<ActionResult<CaseDTO>> GetCase(int id)
        {
            var Case = await _context.Cases.All
                 //.Include(e => e.Case)
                 .SingleOrDefaultAsync(e => e.Id == id);

            if (Case == null)
            {
                return NotFound();
            }

            var casesDto = _mapper.Map<CaseDTO>(Case);

            return casesDto;
        }


        // PUT: api/Case/updateCase/5
        [HttpPut("updateCase/{d}")]
        public async Task<IActionResult> PutCase(int id, CaseDTO casesDTO)
        {
            if (id != casesDTO.Id)
            {
                return NotFound();
            }

            var _Case = await _context.Cases.All.SingleOrDefaultAsync(e => e.Id == id);

            if (_Case == null)
            {
                return NotFound();
            }


            // Update charity model with values from DTO
            _mapper.Map(casesDTO, _Case);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var _case = await _context.Cases.All.SingleOrDefaultAsync(o => o.Id == id);
                if (_case == null)
                {

                }
                if (!CasesExists(id))
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

        private bool CasesExists(int id)
        {
            throw new NotImplementedException();
        }


        // Create: api/Cases/AddNewCases
        [HttpPost("AddNewCase")]
        public async Task<ActionResult<CaseDTO>> CreateCase(CaseDTO caseCreateDto)
        {
            // map the DTO to a Charity entity
            var Cases = _mapper.Map<Case>(caseCreateDto);
            // add the entity to the context and save changes
            _context.Cases.Add(Cases);
            await _context.SaveChangesAsync();

            // map the entity back to a DTO and return it
            //var caseDto = _mapper.Map<CaseDTO>(case);

            return CreatedAtAction(nameof(GetCase), new { id = Cases.Id }, caseCreateDto);
        }
        
        // Create: api/Cases/AddCharity
        [HttpPost("AddCharity")]
        public async Task<IActionResult> AddCharity(int caseId,int charityId)
        {
            // check if case exists
            var Cases = await _context.Cases.All.SingleOrDefaultAsync(e => e.Id == caseId);
            if (Cases == null)
            {
                return NotFound("Case not found");
            }

            // add charity to case 
            var charity = _context.Charities.All.SingleOrDefault(e => e.Id == charityId);
            if (charity == null)
            {
                return NotFound("Charity not found");
            }
    
            Cases.Charity =charity;
            await _context.SaveChangesAsync();
            return Ok(new { message = "Case created successfully" });
        }


        // DELETE: api/Cases/deleteCase
        [HttpDelete("deleteCase/{id}")]
        public async Task<ActionResult<CaseDTO>> Delete(int id)
        {
            var _Case = await _context.Cases.All.SingleOrDefaultAsync(e => e.Id == id);

            if (_Case == null)
            {
                return NotFound();
            }

            _context.Cases.Remove(_Case);
            await _context.SaveChangesAsync();

            var CasesDTO = _mapper.Map<CaseDTO>(_Case);

            return Ok(CasesDTO);
        }
    }
}
