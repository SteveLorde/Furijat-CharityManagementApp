using BackEndAPI.Models;
using System.Collections.Generic;

namespace BackEndAPI.Interfaces
{
    public interface IGenericService<T>
    {
        public IEnumerable<T> Get();
        public T GetByID(int ID);
        public void Create(T model);
        public void Update(T model);
        public void Delete(T model);
    }
}
