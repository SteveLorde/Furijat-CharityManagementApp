using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEndAPI.Models;
using BackEndAPI.Interfaces;
using BackEndAPI.Data.Interfaces;

namespace BackEndAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CasesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CasesController(IAppDbContext context)
        {
            _context = context;
        }

        // GET: api/Cases
        [HttpGet]
        public ActionResult<IEnumerable<Case>> GetCases()
        {
            return _context.Cases.ToList();
        }

        // GET: api/Cases/5
        [HttpGet("{id}")]
        public ActionResult<Case> GetCase(int id)
        {
            var @case = _context.Cases.Find(id);

            if (@case == null)
            {
                return NotFound();
            }

            return @case;
        }

        // POST: api/Cases
        [HttpPost]
        public ActionResult<Case> PostCase(Case @case)
        {
            _context.Cases.Add(@case);
            _context.SaveChanges();

            return CreatedAtAction("GetCase", new { id = @case.CaseId }, @case);
        }

        // PUT: api/Cases/5
        [HttpPut("{id}")]
        public IActionResult PutCase(int id, Case @case)
        {
            if (id != @case.CaseId)
            {
                return BadRequest();
            }

            _context.Entry(@case).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Cases/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCase(int id)
        {
            var @case = _context.Cases.Find(id);

            if (@case == null)
            {
                return NotFound();
            }

            _context.Cases.Remove(@case);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
