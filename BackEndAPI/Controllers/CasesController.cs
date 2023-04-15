using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEndAPI.Models;
using BackEndAPI.Interfaces;
using BackEndAPI.Data.Interfaces;
using System.Threading.Tasks;
using BackEndAPI.Views;
using BackEndAPI.DTOs;

namespace BackEndAPI.Controllers
{
    public class CasesController : BaseApiController
    {
        private readonly IAppDbContext _context;

        public CasesController(IAppDbContext context)
        {
            _context = context;
        }

        // GET: api/Cases
        [HttpGet]
        public ActionResult<IEnumerable<Case>> GetCases()
        {
            return _context.Cases.All.ToList();
        }

        // GET: api/Cases/getCase/5
        [HttpGet("(getCase/{id}")]

       
        public async Task<ActionResult<Case>> GetCase(int id)
        {
            var _Case = await _context.Cases.All

                .SingleOrDefaultAsync(e => e.Id == id);

            if (_Case == null)
            {
                return NotFound();
            }
            return _Case;
        }


        // POST: api/Cases/AddNewCase
        [HttpPost("AddNewCase")]
        public async Task<ActionResult<Case>> PostCase(Case _case)
        {
            await _context.Cases.AddAsync(_case);
            await _context.SaveChangesAsync();
            return _case;
        }

        // PUT: api/Cases/updateCase/5
        [HttpPut("updateCase/{id}")]
        public async Task<IActionResult> PutCase(int id, Case _case)
        {
            if (id != _case.Id)
            {
                return BadRequest();
            }

            _context.Cases.Update(_case).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Cases/deleteCase/5
        [HttpDelete("deleteCase/{id}")]
        public async Task<IActionResult> DeleteCase(int id)
        {
            var _case = await _context.Cases.All.SingleOrDefaultAsync(e => e.Id == id); 

            if (_case == null)
            {
                return NotFound();
            }

            _context.Cases.Remove(_case);
            await _context.SaveChangesAsync();

            return NoContent();
        }




    }
}
