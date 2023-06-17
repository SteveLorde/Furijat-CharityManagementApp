using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using BackEndAPI.Database;
using BackEndAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEndAPI.Data
{
    public class Seed
    {
        public static async Task SeedUser(FurijatContext context)
        {
            if (await context.Users.AnyAsync()) return;

            var userData = await File.ReadAllTextAsync("Data/UserSeedData.json");
            var users = JsonSerializer.Deserialize<List<User>>(userData);
            foreach (var user in users)
            {
                using var hmac = new HMACSHA512();
                user.UserName = user.UserName.ToLower();
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("12345"));
                user.PasswordSalt = hmac.Key;

                context.Users.Add(user);
            }
            await context.SaveChangesAsync();
        }

        public static async Task SeedCharities(FurijatContext context)
        {
            if (await context.Charities.AnyAsync()) return;

            var charityData = await File.ReadAllTextAsync("Data/CharitySeedData.json");
            var Charities = JsonSerializer.Deserialize<List<Charity>>(charityData);
            foreach (var charity in Charities)
            {
                context.Charities.Add(charity);
            }
            await context.SaveChangesAsync();
        }

    }
}
