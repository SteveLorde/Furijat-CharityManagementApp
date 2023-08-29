using BackEndAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEndAPI.Data
{
    public class DataContext : DbContext
    {
        // Database Tables
        //-----------------
        
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        //public DbSet<Donator> Donators { get; set; }
        //public DbSet<Charity> Charities { get; set; }
        //public DbSet<Case> Cases { get; set; }
        
        
    }
}