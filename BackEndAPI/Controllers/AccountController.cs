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
        public async Task<ActionResult<UserVM>> Register(RegisterDto _user)
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
            return new UserVM()
            {
                UserName = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
        }
        private async Task<bool> UserExists(string username)
        {
            return await _db.Users.All.AnyAsync(user => user.UserName == username.ToLower());
        }
    }
}
