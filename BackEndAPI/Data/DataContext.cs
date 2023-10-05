using BackEndAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEndAPI.Data
{
    public class DataContext : DbContext
    {
        // Database Tables
        //-----------------

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
           modelBuilder.Entity<User>()
               .HasData(
               new User { Id = 0, username = null, email = null, password = null, passwordhash = null, usertype = null },
               new User { Id = 0, username = null, email = null, password = null, passwordhash = null, usertype = null },
               new User { Id = 0, username = null, email = null, password = null, passwordhash = null, usertype = null },
               new User { Id = 0, username = null, email = null, password = null, passwordhash = null, usertype = null }
           );
           */
            modelBuilder.Entity<Charity>().ToTable("Charities").HasData(
                new Charity { Id = 1, username = "charity1", email = "Charity1@gmail.com", password = "1234", passwordhash = "$2y$10$GG7BIOY/0GdsliwsztYf7OSfjtitqXM57rNe0d.vpI4FBbl54FN4C", usertype = "charity", CharityId = 1, charityname = "5er Masr", description = "Charity Description 1", phonenumber = 01110746800, Cases  = null },
                new Charity { Id = 2, username = "charity2", email = "Charity2@gmail.com", password = "1234", passwordhash = "$2y$10$GG7BIOY/0GdsliwsztYf7OSfjtitqXM57rNe0d.vpI4FBbl54FN4C", usertype = "charity", CharityId = 2, charityname = "2ed fe 2ed", description = "Charity Description 2", phonenumber = 01110746800 , Cases = null },
                new Charity { Id = 3, username = "charity3", email = "Charity3@gmail.com", password = "1234", passwordhash = "$2y$10$GG7BIOY/0GdsliwsztYf7OSfjtitqXM57rNe0d.vpI4FBbl54FN4C", usertype = "charity", CharityId = 3, charityname = "Charity 3", description = "Charity Description 3", phonenumber = 01110746800 , Cases = null }
            );
            modelBuilder.Entity<Case>().ToTable("Cases").HasData(
                new Case { Id = 4, username = "ahmedtest", email = "ahmed@gmail.com", password = "1234", passwordhash = "$2y$10$GG7BIOY/0GdsliwsztYf7OSfjtitqXM57rNe0d.vpI4FBbl54FN4C", usertype = "case", CaseId = 1, Name = "Ahmed", description = "Debted for furniture", Address = "Address Test", currentdonations = 0, Totalneeded = 5000, Status = "active", CharityId = 1 , Charity = { Id = 1, username = "charity1", email = "Charity1@gmail.com", password = "1234", passwordhash = "$2y$10$GG7BIOY/0GdsliwsztYf7OSfjtitqXM57rNe0d.vpI4FBbl54FN4C", usertype = "charity", CharityId = 1, charityname = "5er Masr", description = "Charity Description 1", phonenumber = 01110746800} },
                new Case { Id = 5, username = "engy", email = "engy@gmail.com", password = "1234", passwordhash = "$2y$10$GG7BIOY/0GdsliwsztYf7OSfjtitqXM57rNe0d.vpI4FBbl54FN4C", usertype = "case", CaseId = 2, Name = "Engy", description = "Case Description 2", Address = "Address Test", currentdonations = 0, Totalneeded = 5000, Status = "active", CharityId = 1, Charity = null},
                new Case { Id = 6, username = "omar", email = "Omar@gmail.com", password = "1234", passwordhash = "$2y$10$GG7BIOY/0GdsliwsztYf7OSfjtitqXM57rNe0d.vpI4FBbl54FN4C", usertype = "case", CaseId = 3, Name = "Omar", description = "Debted for Appliances", Address = "Address Test", currentdonations = 0, Totalneeded = 5000, Status = "active", CharityId = 2, Charity = null}
            );

            modelBuilder.Entity<Donator>().ToTable("Donators").HasData(
                new Donator { Id = 7, username = "donatortest", email = "donator@gmail.com", password = "1234", passwordhash = "$2y$10$GG7BIOY/0GdsliwsztYf7OSfjtitqXM57rNe0d.vpI4FBbl54FN4C", usertype = "donator", DonatorId = 1, paymenttype = "null", phonenumber = 01110746800 , DonatedCase = null}
            );
            
            modelBuilder.Entity<Admin>().ToTable("Admins");

            modelBuilder.Entity<News>().HasData(
                new News { Id = 8, date = "2-12-2023", title = "Title 1", subtitle = "Subtitle 1", body = " LOL " },
                new News { Id = 9, date = "3-12-2023", title = "Title 2", subtitle = "Subtitle 2", body = " LOL " },
                new News { Id = 10, date = "4-12-2023", title = "Title 3", subtitle = "Subtitle 3", body = " LOL " }
            );
        }
 

        public DbSet<User> Users { get; set; }
        public DbSet<News> News { get; set; }
        /*
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Donator> Donators { get; set; }
        public DbSet<Charity> Charities { get; set; }
        public DbSet<Case> Cases { get; set; }
        */


    }
}