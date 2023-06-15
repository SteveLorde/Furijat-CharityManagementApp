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
        public DbSet<CharityDonators> CharityDonators { get; set; }
        public DbSet<CreditorCases> CreditorCases { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Charity>().ToTable("Charities");
            modelBuilder.Entity<Case>().ToTable("Cases");
            modelBuilder.Entity<Admin>().ToTable("Admins");
            modelBuilder.Entity<Donator>().ToTable("Donators");
            modelBuilder.Entity<Creditor>().ToTable("Creditors");
            modelBuilder.Entity<CharityManagment>().ToTable("CharityManagment");
            modelBuilder.Entity<CreditorCases>().ToTable("CreditorCases");
        }

    }
}
