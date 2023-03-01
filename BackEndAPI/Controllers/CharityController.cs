using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEndAPI.Models;
using BackEndAPI.Interfaces;
using BackEndAPI.Data.Interfaces;
using System.Threading.Tasks;
using BackEndAPI.Views;

namespace BackEndAPI.Controllers
{
    public class CharityController : BaseApiController
    {
        private readonly IAppDbContext _context;
       

        public CharityController(IAppDbContext context)
        {
            _context = context;
        }

        // GET: api/Charity
        [HttpGet]
        public ActionResult<IEnumerable<Charity>> GetCharity()
        {
            return _context.Charities.All.ToList();
        }
        // GET: api/Charity/get a specific charity
        [HttpGet("(getCharity/{id}")]
        public async Task<ActionResult<Charity>> GetCharity(int id)
        {
            var _Charity = await _context.Charities.All
               
                .SingleOrDefaultAsync(e => e.CharityId == id);

            if (_Charity == null)
            {
                return NotFound();
            }
            return _Charity;
        }
        // POST: api/Cases/AddNewCharity
        [HttpPost("AddNewCharity")]
        public async Task<ActionResult<Charity>> PostCharity(Charity _Charity)
        {
            await _context.Charities.AddAsync(_Charity);
            await _context.SaveChangesAsync();

            return _Charity;
        }

        // PUT: api/Charities/updateCharity
        [HttpPut("updateCharity/{id}")]
        public async Task<IActionResult> PutCharity(int id, Charity _Charity)
        {
            if (id != _Charity.CharityId)
            {
                return BadRequest();
            }

            _context.Charities.Update(_Charity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Charities/deleteCharity
        [HttpDelete("deleteCharity/{id}")]
        public async Task<IActionResult> DeleteCharity(int id)
        {
            var _Charity = await _context.Charities.All.SingleOrDefaultAsync(e => e.CharityId == id); ;

            if (_Charity == null)
            {
                return NotFound();
            }

            _context.Charities.Remove(_Charity);
            await _context.SaveChangesAsync();

            return NoContent();
        }




    }

}
