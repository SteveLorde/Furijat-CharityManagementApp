using BackEndAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEndAPI.Database
{
    public class FurijatContext:DbContext
    {
        public FurijatContext(DbContextOptions<FurijatContext> option) : base(option)
        {
        
        }
        public DbSet<User> User { get; set; }
        public DbSet<CasePayment> CasePayment { get; set; }
        public DbSet<UserType> UserType { get; set; }
        public DbSet<Charity> Charity { get; set; }
        public DbSet<Cases> Cases { get; set; }

    }
}
