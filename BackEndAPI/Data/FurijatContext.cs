using BackEndAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEndAPI.Database
{
    public class FurijatContext:DbContext
    {
        public FurijatContext(DbContextOptions<FurijatContext> option) : base(option)
        {
        
        }
        public DbSet<User> Users { get; set; }
        public DbSet<CasePayment> CasePayments { get; set; }
        public DbSet<UserType> UserType { get; set; }
        public DbSet<Charity> Charities { get; set; }
        public DbSet<Case> Cases { get; set; }

    }
}
