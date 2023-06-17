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
using BackEndAPI.Views;

namespace BackEndAPI.Controllers
{

    public class UserController : BaseApiController
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;


        public UserController(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Users
        [HttpGet]

        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsers()
        {
            // retrieve all Users from the database
            var users = await _context.Users.All.ToListAsync();

            // map the entities to DTOs and return them
            return _mapper.Map<IEnumerable<UserDTO>>(users).ToList();
        }


        // GET: api/Users/getUser/5
        [HttpGet("getUser/{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(int id)
        {
            var User = await _context.Users.All
                 //.Include(e => e.User)
                 .SingleOrDefaultAsync(e => e.Id == id);

            if (User == null)
            {
                return NotFound();
            }

            var userDto = _mapper.Map<UserDTO>(User);

            return userDto;
        }


        // PUT: api/User/updateUser/5
        [HttpPut("updateUser/{id}")]
        public async Task<IActionResult> PutUser(int id, UserDTO userDTO)
        {
            if (id != userDTO.Id)
            {
                return NotFound();
            }

            var _User = await _context.Users.All.SingleOrDefaultAsync(e => e.Id == id);

            if (_User == null)
            {
                return NotFound();
            }


            // Update user model with values from DTO
            _mapper.Map(userDTO, _User);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var _user = await _context.Users.All.SingleOrDefaultAsync(o => o.Id == id);
                if (_user == null)
                {

                }
                if (!UserExists(id))
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

        private bool UserExists(int id)
        {
            throw new NotImplementedException();
        }


        // Create: api/Users/AddNewUsers
        [HttpPost("AddNewUser")]
        public async Task<ActionResult<UserDTO>> CreateCUser(UserDTO userCreateDto)
        {
            // map the DTO to a Users entity
            var User = _mapper.Map<User>(userCreateDto);

            // add the entity to the context and save changes
            _context.Users.Add(User);
            await _context.SaveChangesAsync();

            // map the entity back to a DTO and return it
            //var userDto = _mapper.Map<UserDTO>(user);

            return CreatedAtAction(nameof(GetUser), new { id = User.Id },userCreateDto);
        }


        // DELETE: api/Users/deleteUser
        [HttpDelete("deleteUser/{id}")]
        public async Task<ActionResult<UserDTO>> Delete(int id)
        {
            var _User = await _context.Users.All.SingleOrDefaultAsync(e => e.Id == id);

            if (_User == null)
            {
                return NotFound();
            }

            _context.Users.Remove(_User);
            await _context.SaveChangesAsync();

            var UserDTO = _mapper.Map<UserDTO>(_User);

            return Ok(UserDTO);
        }
    }
}
