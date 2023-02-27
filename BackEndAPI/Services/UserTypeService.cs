using BackEndAPI.Database;
using BackEndAPI.Interfaces;
using BackEndAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace BackEndAPI.Services
{
    public class UserTypeService : IGenericService<UserType>
    {
        private readonly FurijatContext db;
        public UserTypeService(FurijatContext db)
        {
            this.db = db;
        }
        public void Create(UserType model)
        {
            db.UserType.Add(model);
            db.SaveChanges();
        }

        public void Delete(UserType model)
        {
            db.UserType.Remove(model);
            db.SaveChanges();
        }

        public IEnumerable<UserType> Get()
        {
            var data = db.UserType.Select(a => a);
            return data;
        }

        public UserType GetByID(int ID)
        {
            var data = db.UserType.Where(a => a.UserTypeId == ID).FirstOrDefault();
            return data;
        }

        public void Update(UserType model)
        {
            db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
