using BackEndAPI.Database;
using BackEndAPI.Interfaces;
using BackEndAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace BackEndAPI.Services
{
    public class Charitieservice : IGenericService<Charity>
    {
        private readonly FurijatContext db;
        public Charitieservice(FurijatContext db)
        {
            this.db = db;
        }
        public void Create(Charity model)
        {
            db.Charities.Add(model);
            db.SaveChanges();
        }

        public void Delete(Charity model)
        {
            db.Charities.Remove(model);
            db.SaveChanges();
        }

        public IEnumerable<Charity> Get()
        {
            var data = db.Charities.Select(a => a);
            return data;
        }

        public Charity GetByID(int ID)
        {
            var data = db.Charities.Where(a => a.CharityId == ID).FirstOrDefault();
            return data;
        }

        public void Update(Charity model)
        {
            db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
