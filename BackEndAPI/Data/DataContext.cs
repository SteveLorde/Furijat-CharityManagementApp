using Microsoft.EntityFrameworkCore;

namespace BackEndAPI.Data
{
    public class DataContext : DbContext
    {
        // Database Tables
        //-----------------
        
        //public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("FurijatDataBase=Database.db");
        }
    }
}