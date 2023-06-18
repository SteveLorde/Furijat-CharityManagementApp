using BackEndAPI.Data.Entites;
using BackEndAPI.Models;
using Microsoft.Data.SqlClient;
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
        public DbSet<Case> Cases { get; set; }
        public DbSet<Donator> Donators { get; set; }
        public DbSet<Donation> Donation { get; set; }
        public DbSet<Admin> Admin { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Charity>().ToTable("Charities");
            modelBuilder.Entity<Case>().ToTable("Cases");
            modelBuilder.Entity<Admin>().ToTable("Admin");
            modelBuilder.Entity<Donator>().ToTable("Donators");
            modelBuilder.Entity<Creditor>().ToTable("Creditor").HasKey(x => new { x.CreditorID, x.CaseID });
            modelBuilder.Entity<Donation>().ToTable("Donation").HasKey(d => new { d.CaseId,d.DonatorId,d.CharityId });
            base .OnModelCreating(modelBuilder);
        }

    }
}
