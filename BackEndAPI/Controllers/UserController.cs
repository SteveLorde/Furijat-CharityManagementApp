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
    public class UserController : BaseApiController
    {
        private readonly IAppDbContext _context;

        public UserController(IAppDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetCases()
        {
            return _context.Users.All.ToList();
        }

        // GET: api/Users/get a pecific User
        [HttpGet("(getUser/{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var _User = await _context.Users.All
              
                .SingleOrDefaultAsync(e => e.Id == id);

            if (_User == null)
            {
                return NotFound();
            }
            return _User;
        }

        // POST: api/Users/AddNewUser
        [HttpPost("AddNewUser")]
        public async Task<ActionResult<User>> PostUser(User _User)
        {
            await _context.Users.AddAsync(_User);
            await _context.SaveChangesAsync();

            return _User;
        }

        // PUT: api/Users/updateUser
        [HttpPut("updateUser/{id}")]
        public async Task<IActionResult> PutUser(int id, User _User)
        {
            if (id != _User.Id)
            {
                return BadRequest();
            }

            _context.Users.Update(_User).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Users/deleteUser
        [HttpDelete("deleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var _User = await _context.Users.All.SingleOrDefaultAsync(e => e.Id == id); ;

            if (_User == null)
            {
                return NotFound();
            }

            _context.Users.Remove(_User);
            await _context.SaveChangesAsync();

            return NoContent();
        }




    }
}

