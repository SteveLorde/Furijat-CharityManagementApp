using BackEndAPI.Data.Entites;
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
        public DbSet<Creditor> Creditor { get; set; }

        public DbSet<Charity> Charities { get; set; }
        public DbSet<CharityDonators> CharityDonators { get; set; }
        public DbSet<CreditorCases> CreditorCases { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Case>().ToTable("Cases");
            modelBuilder.Entity<Admin>().ToTable("Admin");
            modelBuilder.Entity<Donator>().ToTable("Donatores");
            modelBuilder.Entity<Creditor>().HasKey(x => new { x.CreditorID, x.CaseID });
            modelBuilder.Entity<CharityManagment>().HasKey(CM => new { CM.CaseID, CM.CharityID,CM.CreditorID});
            modelBuilder.Entity<CharityDonators>().HasKey(CD => new {CD.DonatorID, CD.CharityID });
            modelBuilder.Entity<CreditorCases>().HasKey(CC => new { CC.CaseID, CC.CreditorID });




        }

    }
}
