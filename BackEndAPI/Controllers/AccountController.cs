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
            var user = new User()
            {
                UserName = _user.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(_user.Password)),
                PasswordSalt = hmac.Key
            };
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
            return new UserDTO()
            {
                UserName = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
        }
        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO _user)
        {

            var user = await _db.Users.All
                //.Include(e => e.UserType)
                .SingleOrDefaultAsync(e => e.UserName == _user.Username.ToLower()); ;

            if (user == null) return Unauthorized("Invalid username");

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(_user.Password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password");
            }
            return new UserDTO()
            {
                UserName = user.UserName,
                Id = user.Id,
                // UserTypeID = user.UserType.Id,
                Token = _tokenService.CreateToken(user)
            };
        }
        private async Task<bool> UserExists(string username)
        {
            return await _db.Users.All.AnyAsync(user => user.UserName == username.ToLower());
        }
    }
}
