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
    public class CasePaymentController : BaseApiController
    {
        private readonly IAppDbContext _context;

        public CasePaymentController(IAppDbContext context)
        {
            _context = context;
        }

        // GET: api/CasePayment
        [HttpGet]
        public ActionResult<IEnumerable<CasePayment>> GetCasePayments()
        {
            return _context.CasePayments.All.ToList();
        }

        // GET: api/Users/get CasePayment
        [HttpGet("(getCasePayment/{id}")]
        public async Task<ActionResult<CasePayment>> GetCasePayment(int id)
        {
            var _CasePayment = await _context.CasePayments.All

                .SingleOrDefaultAsync(e => e.Id == id);

            if (_CasePayment == null)
            {
                return NotFound();
            }
            return _CasePayment;
        }

        // POST: api/CasePayment/AddNewCasePayment
        [HttpPost("AddNewCasePayment")]
        public async Task<ActionResult<CasePayment>> PostUser(CasePayment _CasePayment)
        {
            await _context.CasePayments.AddAsync(_CasePayment);
            await _context.SaveChangesAsync();

            return _CasePayment;
        }

        // PUT: api/CasePayments/updateCasePayment
        [HttpPut("updateCasePayment/{id}")]
        public async Task<IActionResult> PutCasePayment(int id, CasePayment _CasePayment)
        {
            if (id != _CasePayment.Id)
            {
                return BadRequest();
            }

            _context.CasePayments.Update(_CasePayment).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/CasePayment/deleteCasePayment
        [HttpDelete("deleteCasePayment/{id}")]
        public async Task<IActionResult> DeleteCasePayment(int id)
        {
            var _CasePayment = await _context.CasePayments.All.SingleOrDefaultAsync(e => e.Id == id); ;

            if (_CasePayment == null)
            {
                return NotFound();
            }

            _context.CasePayments.Remove(_CasePayment);
            await _context.SaveChangesAsync();

            return NoContent();
        }




    }
}
