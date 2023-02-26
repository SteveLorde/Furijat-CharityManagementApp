using BackEndAPI.Data.Interfaces;
using BackEndAPI.Database;
using BackEndAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace BackEndAPI.Data
{
    public class ScopedDbContext : IAppDbContext
    {
        private FurijatContext _context;
        protected IHttpContextAccessor _httpContextAccessor;
        public IRepository<User> Users { get; private set; }

        public IRepository<Cases> Cases { get; private set; }

        public IRepository<CasePayment> CasePayments { get; private set; }

        public IRepository<Charity> Charities { get; private set; }

        public IRepository<UserType> Roles { get; private set; }
        public ScopedDbContext(FurijatContext context, IHttpContextAccessor httpContextAccessor)

        {
            this._context = context;
            this._httpContextAccessor = httpContextAccessor;
            FillProperties();
        }
        private void FillProperties()
        {
            Users = new Repository<User>(_context, _httpContextAccessor);
            Roles = new Repository<UserType>(_context, _httpContextAccessor);
            Cases = new Repository<Cases>(_context, _httpContextAccessor);
            CasePayments = new Repository<CasePayment>(_context, _httpContextAccessor);
            Charities = new Repository<Charity>(_context, _httpContextAccessor);
        }

        #region Database Methods
        public void Migrate() => _context.Database.Migrate();
        public IDbContextTransaction BeginTransaction() => _context.Database.BeginTransaction();
        public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
            => _context.Database.BeginTransactionAsync(cancellationToken);

        public void RollBack() => _context.Database.RollbackTransaction();
        public Task RollBackAsync(CancellationToken cancellationToken = default)
            => _context.Database.RollbackTransactionAsync(cancellationToken);
        public void Commit() => _context.Database.CommitTransaction();
        public Task CommitAsync(CancellationToken cancellationToken = default)
            => _context.Database.CommitTransactionAsync(cancellationToken);
        #endregion

        #region DbContext Members
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
            => _context.SaveChangesAsync(cancellationToken);
        public int SaveChanges() => _context.SaveChanges();
        public EntityEntry Add([NotNull] object entity) => _context.Add(entity);

        public EntityEntry<TEntity> Add<TEntity>([NotNull] TEntity entity) where TEntity : class
       => _context.Add(entity);

        public ValueTask<EntityEntry> AddAsync([NotNull] object entity, CancellationToken cancellationToken = default)
       => _context.AddAsync(entity, cancellationToken);

        public ValueTask<EntityEntry<TEntity>> AddAsync<TEntity>([NotNull] TEntity entity, CancellationToken cancellationToken = default) where TEntity : class
         => _context.AddAsync(entity, cancellationToken);

        public void AddRange([NotNull] IEnumerable<object> entities) => _context.AddRange(entities);
        public void AddRange([NotNull] params object[] entities) => _context.AddRange(entities);

        public Task AddRangeAsync([NotNull] IEnumerable<object> entities, CancellationToken cancellationToken = default)
        => _context.AddRangeAsync(entities, cancellationToken);

        public Task AddRangeAsync([NotNull] params object[] entities)
       => _context.AddRangeAsync(entities);

        public void Dispose() => _context.Dispose();

        public ValueTask DisposeAsync() => _context.DisposeAsync();


        public EntityEntry Remove([NotNull] object entity) => _context.Remove(entity);
        public EntityEntry<TEntity> Remove<TEntity>([NotNull] TEntity entity) where TEntity : class
       => _context.Remove(entity);

        public void RemoveRange([NotNull] params object[] entities) => _context.RemoveRange(entities);

        public void RemoveRange([NotNull] IEnumerable<object> entities) => _context.RemoveRange(entities);

        public int SaveChanges(bool acceptAllChangesOnSuccess) => _context.SaveChanges(acceptAllChangesOnSuccess);

        public Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        => _context.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);

        public EntityEntry Update([NotNull] object entity) => _context.Update(entity);

        public EntityEntry<TEntity> Update<TEntity>([NotNull] TEntity entity) where TEntity : class
       => _context.Update(entity);

        public void UpdateRange([NotNull] params object[] entities) => _context.UpdateRange(entities);

        public void UpdateRange([NotNull] IEnumerable<object> entities) => _context.UpdateRange(entities);

        #endregion
    }
}
