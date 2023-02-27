using BackEndAPI.Database;
using BackEndAPI.Interfaces;
using BackEndAPI.Models;
using System.Collections.Generic;
using System.Linq;
namespace BackEndAPI.Services
{
    public class UserService : IGenericService<User>
    {
        private readonly FurijatContext db;
        public UserService(FurijatContext db)
        {
            this.db = db;
        }
        public void Create(User model)
        {
            db.Users.Add(model);
            db.SaveChanges();
        }

        public void Delete(User model)
        {
            db.Users.Remove(model);
            db.SaveChanges();
        }

        public IEnumerable<User> Get()
        {
            var data = db.Users.Select(a => a);
            return data;
        }

        public User GetByID(int ID)
        {
            var data = db.Users.Where(a => a.UserId == ID).FirstOrDefault();
            return data;
        }

        public void Update(User model)
        {
            db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
