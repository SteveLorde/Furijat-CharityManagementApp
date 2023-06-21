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
using BackEndAPI.Views;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace BackEndAPI.Controllers
{

    public class CreditorController : BaseApiController
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public CreditorController(IAppDbContext context, IMapper mapper, ITokenService tokenService)
        {
            _context = context;
            _mapper = mapper;
            _tokenService = tokenService;
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
                 .SingleOrDefaultAsync(e => e.CreditorID == id);

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

            var _Creditor = await _context.Creditors.All.SingleOrDefaultAsync(e => e.CreditorID == id);

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
                var _creditor = await _context.Creditors.All.SingleOrDefaultAsync(o=>o.CreditorID == id);
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

            return CreatedAtAction(nameof(GetCreditor), new { id = creditor.CreditorID }, creditorCreateDto);
        }


        // DELETE: api/Creditorss/deleteCreditor
        [HttpDelete("deleteCreditor/{id}")]
        public async Task<ActionResult<CreditorDTO>> Delete(int id)
        {
            var _Creditor = await _context.Creditors.All.SingleOrDefaultAsync(e => e.CreditorID == id);

            if (_Creditor == null)
            {
                return NotFound();
            }

            _context.Creditors.Remove(_Creditor);
            await _context.SaveChangesAsync();

            var creditorDTO = _mapper.Map<CreditorDTO>(_Creditor);

            return Ok(creditorDTO);
        }
        [HttpPost("register")]
        public async Task<ActionResult<CreditorDTO>> Register(RegisterCreditorDTO _user)
        {
            if (await UserExists(_user.UserName)) return BadRequest("Username is taken");
            using var hmac = new HMACSHA512();

            var _case = await _context.Cases.All.SingleOrDefaultAsync(e => e.Id == _user.CaseID);

            if (_case == null) return BadRequest("Invalid Case Id");

            var creditor = new Creditor() { 
            UserName = _user.UserName.ToLower(),
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(_user.Password)),
            PasswordSalt = hmac.Key,
            CaseID = _case.Id,
            Phone = _user.Phone,
            Description = _user.Description,
            Address=_user.Address,
            
            };


            _context.Creditors.Add(creditor);
            await _context.SaveChangesAsync();
            var dto=  _mapper.Map<CreditorDTO>(creditor);
            dto.Token = _tokenService.CreateToken(creditor);
            return dto;
        }
        [HttpPost("login")]
        public async Task<ActionResult<CreditorDTO>> Login(LoginDTO _creditor)
        {

            var creditor = await _context.Creditors.All
                //.Include(e => e.UserType)
                .SingleOrDefaultAsync(e => e.UserName ==_creditor.Username.ToLower()); ;
            

            if (creditor == null) return Unauthorized("Invalid username");

            using var hmac = new HMACSHA512(creditor.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(_creditor.Password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != creditor.PasswordHash[i]) return Unauthorized("Invalid password");
            }

            //   var charity = user is Admin ? await _context.Charities.All.SingleOrDefaultAsync(e => e.Id == (user as Admin).Charity.Id) : await _context.Charities.All.SingleOrDefaultAsync(e => e.Id == (user as Case).Charity.Id);

            return new CreditorDTO()
            {
                UserName = creditor.UserName,
                Id = creditor.CreditorID,
                Phone = creditor.Phone,
                Description = creditor.Description,
                Payment_Account = creditor.Payment_Account,
                Address = creditor.Address,
                Deserves_Amount = creditor.Deserves_Amount,
                Token = _tokenService.CreateToken(creditor),
                CaseID = creditor.CaseID
            };
        }
        private async Task<bool> UserExists(string username)
        {
            return await _context.Creditors.All.AnyAsync(user => user.UserName == username.ToLower());
        }
    }
}

