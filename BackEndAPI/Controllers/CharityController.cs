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
using BackEndAPI.Services;
using System.Security.Cryptography;
using System.Text;

namespace BackEndAPI.Controllers
{

    public class CharityController : BaseApiController
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public CharityController(IAppDbContext context, IMapper mapper, ITokenService tokenService)
        {
            _context = context;
            _mapper = mapper;
            _tokenService = tokenService;
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

            _context.Charities.Update(_Charity);

            try
            {
                await _context.SaveChangesAsync();
                return Ok("updated successfully");
            }
            catch (DbUpdateConcurrencyException)
            {
                var _charity = await _context.Charities.All.SingleOrDefaultAsync(o => o.Id == id);
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
        // GET: api/Charity/getCharityCases/5
        [HttpGet("getCharityCases/{id}")]
        public async Task<ActionResult<ICollection<CharityDTO>>> GetCharityCases(int id)
        {
            var Charity = await _context.Charities.All
                 //.Include(e => e.Charity)
                 .SingleOrDefaultAsync(e => e.Id == id);

            if (Charity == null)
            {
                return NotFound();
            }

            var casesDto = _mapper.Map<ICollection<CharityDTO>>(Charity.Cases).ToList();

            return casesDto;
        }
        [HttpPost("register")]
        public async Task<ActionResult<CharityDTO>> Register(RegisterCharityDTO _user)
        {
            if (await UserExists(_user.UserName)) return BadRequest("Username is taken");
            using var hmac = new HMACSHA512();

            //var _case = await _context.Cases.All.SingleOrDefaultAsync(e => e.Id == _user.);

           // if (_case == null) return BadRequest("Invalid Case Id");

           var _charity = new Charity()
            {
                UserName = _user.UserName.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(_user.Password)),
                PasswordSalt = hmac.Key,
               //CaseID = _case.Id,
                Phone = _user.Phone,
                Description = _user.Description,
              

            };


            _context.Charities.Add(_charity);
            await _context.SaveChangesAsync();
            var dto = _mapper.Map<CharityDTO>(_charity);
            dto.Token = _tokenService.CreateToken(_charity);
            return dto;
        }
        [HttpPost("login")]
        public async Task<ActionResult<CharityDTO>> Login(LoginDTO _charity)
        {

            var charities = await _context.Charities.All
                //.Include(e => e.UserType)
                .SingleOrDefaultAsync(e => e.UserName == _charity.Username.ToLower()); ;


            if (charities == null) return Unauthorized("Invalid username");

            using var hmac = new HMACSHA512(charities.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(_charity.Password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != charities.PasswordHash[i]) return Unauthorized("Invalid password");
            }

            //   var charity = user is Admin ? await _context.Charities.All.SingleOrDefaultAsync(e => e.Id == (user as Admin).Charity.Id) : await _context.Charities.All.SingleOrDefaultAsync(e => e.Id == (user as Case).Charity.Id);

            return new CharityDTO()
            {
                UserName = charities.UserName,
                Id = charities.Id,
                Phone = charities.Phone,
                Description = charities.Description,
                Bank_Account=charities.Bank_Account,
                Email=charities.Email,
                Location= charities.Location,
                Name = charities.Name,
                Status= charities.Status,
                Website=charities.Website,
                
            };
        }
        private async Task<bool> UserExists(string username)
        {
            return await _context.Charities.All.AnyAsync(user => user.UserName == username.ToLower());
        }
        //}
    }
}
