using BackEndAPI.Data.Entites;
using BackEndAPI.Data.Interfaces;
using BackEndAPI.DTOs;
using BackEndAPI.Interfaces;
using BackEndAPI.Models;
using BackEndAPI.Views;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BackEndAPI.Controllers
{
    public class AccountController:BaseApiController
    {
        private readonly IAppDbContext _db;
        private readonly ITokenService _tokenService;
        public AccountController(IAppDbContext db, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _db = db;
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO _user)
        {
            if (await UserExists(_user.Username)) return BadRequest("Username is taken");
            using var hmac = new HMACSHA512();

            var _charity = await _db.Charities.All.SingleOrDefaultAsync(e => e.Id == _user.CharityId);

            if(_charity == null) return BadRequest("Invalid Charity Id");

            User user = new Models.User();
            if(_user.UserType.ToLower() == "admin")
            {
                user = new Admin()
                {
                    UserName = _user.Username.ToLower(),
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(_user.Password)),
                    PasswordSalt = hmac.Key,
                    UserType = _user.UserType,
                    FirstName = _user.FirstName,
                    LastName = _user.LastName,
                    Charity = _charity
                };
                await _db.Admins.AddAsync(user as Admin);
            }
            else if (_user.UserType.ToLower() == "case")
            {
                user = new Case()
                {
                    UserName = _user.Username.ToLower(),
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(_user.Password)),
                    PasswordSalt = hmac.Key,
                    UserType = _user.UserType,
                    FirstName = _user.FirstName,
                    LastName = _user.LastName,
                    Charity = _charity
                };
                await _db.Cases.AddAsync(user as Case);
            }
            else
                return BadRequest("Invalid user type");

            await _db.SaveChangesAsync();
            return new UserDTO()
            {
                Id = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserType = user.UserType,
                Token = _tokenService.CreateToken(user),
                CharityId = _charity.Id
            };
        }
        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO _user)
        {

            var user = await _db.Users.All
                //.Include(e => e.UserType)
                .SingleOrDefaultAsync(e => e.UserName == _user.Username.ToLower()); ;
            user = user switch
            {
                Admin => await _db.Admins.All
                    .Include(e => e.Charity)
                    .SingleOrDefaultAsync(e => e.UserName == _user.Username.ToLower()),
                Case => await _db.Cases.All
                    .Include(e => e.Charity)
                    .SingleOrDefaultAsync(e => e.UserName == _user.Username.ToLower()),
                Donator => await _db.Donators.All
                    .SingleOrDefaultAsync(e => e.UserName == _user.Username.ToLower()),
                _ => null,
            };

            if (user == null) return Unauthorized("Invalid username");

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(_user.Password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password");
            }

            var charity = user is Admin ? await _db.Charities.All.SingleOrDefaultAsync(e => e.Id == (user as Admin).Charity.Id) : await _db.Charities.All.SingleOrDefaultAsync(e => e.Id == (user as Case).Charity.Id);

            return new UserDTO()
            {
                UserName = user.UserName,
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserType = user.UserType,
                Token = _tokenService.CreateToken(user),
                CharityId = charity.Id
            };
        }
        private async Task<bool> UserExists(string username)
        {
            if( await _db.Admins.All.AnyAsync(user => user.UserName == username.ToLower())) return true;
            if( await _db.Cases.All.AnyAsync(user => user.UserName == username.ToLower())) return true;
            if( await _db.Donators.All.AnyAsync(user => user.UserName == username.ToLower())) return true;
            return false;
        }
    }
}
