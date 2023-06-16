using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace BackEndAPI.Data.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> All { get; }

        EntityEntry<TEntity> Add([NotNullAttribute] TEntity entity);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match);
        TEntity Find(Expression<Func<TEntity, bool>> match);
        ValueTask<EntityEntry<TEntity>> AddAsync([NotNullAttribute] TEntity entity);
        void AddRange([NotNullAttribute] IEnumerable<TEntity> entities);
        void AddRange([NotNullAttribute] params TEntity[] entities);
        Task AddRangeAsync([NotNullAttribute] IEnumerable<TEntity> entities);
        Task AddRangeAsync([NotNullAttribute] params TEntity[] entities);
        EntityEntry<TEntity> Remove([NotNullAttribute] TEntity entity);
        void RemoveRange([NotNullAttribute] params TEntity[] entities);
        void RemoveRange([NotNullAttribute] IEnumerable<TEntity> entities);
        [EditorBrowsable(EditorBrowsableState.Never)]
        string ToString();
        EntityEntry<TEntity> Update([NotNullAttribute] TEntity entity);
        void UpdateRange([NotNullAttribute] params TEntity[] entities);
        void UpdateRange([NotNullAttribute] IEnumerable<TEntity> entities);
        //Task<TEntity> FindAsyncById(int id);
        Task ToListAsync();
        object Where(Func<object, bool> value);
        Task FirstOrDefaultAsync(Func<object, bool> value);
    }
}
