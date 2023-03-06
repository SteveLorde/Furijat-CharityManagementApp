using BackEndAPI.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;
using BackEndAPI.Database;

namespace BackEndAPI.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbSet<T> _orginalSet;
        protected FurijatContext _context;
        protected IHttpContextAccessor _httpContextAccessor;

        IQueryable<T> IRepository<T>.All => _orginalSet;

        public Repository(FurijatContext context, IHttpContextAccessor httpContextAccessor)
        {
            this._context = context;
            _orginalSet = _context.Set<T>();
            this._httpContextAccessor = httpContextAccessor;
        }

        public void Add(T entity) => _orginalSet.Add(entity);

        EntityEntry<T> IRepository<T>.Add(T entity) => _orginalSet.Add(entity);

        public ValueTask<EntityEntry<T>> AddAsync([NotNull] T entity)
       => _orginalSet.AddAsync(entity);

        public void AddRange([NotNull] IEnumerable<T> entities) => _orginalSet.AddRange(entities);

        public Task<T> FindAsync(Expression<Func<T, bool>> match) => _orginalSet.FirstOrDefaultAsync(match);

        public T Find(Expression<Func<T, bool>> match) => _orginalSet.FirstOrDefault(match);


        public void AddRange([NotNull] params T[] entities)
         => _orginalSet.AddRange(entities);

        public Task AddRangeAsync([NotNull] IEnumerable<T> entities)
        => _orginalSet.AddRangeAsync(entities);

        public Task AddRangeAsync([NotNull] params T[] entities)
        => _orginalSet.AddRangeAsync(entities);

        public EntityEntry<T> Remove([NotNull] T entity) => _orginalSet.Remove(entity);

        public void RemoveRange([NotNull] params T[] entities) => _orginalSet.RemoveRange(entities);
        public void RemoveRange([NotNull] IEnumerable<T> entities) => _orginalSet.RemoveRange(entities);

        public EntityEntry<T> Update([NotNull] T entity) => _orginalSet.Update(entity);

        public void UpdateRange([NotNull] params T[] entities) => _orginalSet.UpdateRange(entities);

        public void UpdateRange([NotNull] IEnumerable<T> entities)
         => _orginalSet.UpdateRange(entities);

        public object Update(object charity)
        {
            throw new NotImplementedException();
        }

        public Task FindAsync(int charityId)
        {
            throw new NotImplementedException();
        }

        public Task ToListAsync()
        {
            throw new NotImplementedException();
        }

        public object Where(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }

        public Task FirstOrDefaultAsync(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}
