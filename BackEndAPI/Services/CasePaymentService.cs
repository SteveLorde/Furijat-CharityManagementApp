using BackEndAPI.Database;
using BackEndAPI.Interfaces;
using BackEndAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace BackEndAPI.Services
{
    public class CasePaymentPaymentService : IGenericService<CasePayment>
    {
        private readonly FurijatContext db;
        public CasePaymentPaymentService(FurijatContext db)
        {
            this.db = db;
        }
        public void Create(CasePayment model)
        {
            db.CasePayments.Add(model);
            db.SaveChanges();
        }

        public void Delete(CasePayment model)
        {
            db.CasePayments.Remove(model);
            db.SaveChanges();
        }

        public IEnumerable<CasePayment> Get()
        {
            var data = db.CasePayments.Select(a => a);
            return data;
        }

        public CasePayment GetByID(int ID)
        {
            var data = db.CasePayments.Where(a => a.CasePaymentId == ID).FirstOrDefault();
            return data;
        }

        public void Update(CasePayment model)
        {
            db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
