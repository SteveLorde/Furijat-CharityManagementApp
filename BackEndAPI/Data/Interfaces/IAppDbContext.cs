using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using System.Threading;
using BackEndAPI.Models;

namespace BackEndAPI.Data.Interfaces
{
    public interface IAppDbContext
    {
        public IRepository<User> Users { get; }
        public IRepository<Case> Cases { get; }
        public IRepository<CasePayment> CasePayments { get; }
        public IRepository<Charity> Charities { get; }
        public IRepository<UserType> Roles { get; }
        object Usertypes { get; }
        object UserType { get; set; }
        object UserTypes { get; }
        object usertypes { get; set; }
        
       
        void Migrate();
        Task SaveChangesAsync();
    }
}
