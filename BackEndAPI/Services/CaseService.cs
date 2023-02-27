using BackEndAPI.Database;
using BackEndAPI.Interfaces;
using BackEndAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace BackEndAPI.Services
{
    public class CaseService : IGenericService<Case>
    {
        private readonly FurijatContext db;
        public CaseService(FurijatContext db)
        {
            this.db = db;
        }
        public void Create(Case model)
        {
            db.Cases.Add(model);
            db.SaveChanges();
        }

        public void Delete(Case model)
        {
            db.Cases.Remove(model);
            db.SaveChanges();
        }

        public IEnumerable<Case> Get()
        {
            var data = db.Cases.Select(a => a);
            return data;
        }

        public Case GetByID(int ID)
        {
            var data = db.Cases.Where(a => a.CaseId == ID).FirstOrDefault();
            return data;
        }

        public void Update(Case model)
        {
            db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }
    }
}