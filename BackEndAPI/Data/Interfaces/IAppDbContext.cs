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

        #region Methods
        IDbContextTransaction BeginTransaction();
        Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
        void RollBack();
        Task RollBackAsync(CancellationToken cancellationToken = default);
        void Commit();
        Task CommitAsync(CancellationToken cancellationToken = default);
        #endregion
        void Migrate();

        #region DbContext members

        EntityEntry Add([NotNullAttribute] object entity);
        EntityEntry<TEntity> Add<TEntity>([NotNullAttribute] TEntity entity) where TEntity : class;
        ValueTask<EntityEntry> AddAsync([NotNullAttribute] object entity, CancellationToken cancellationToken = default);
        ValueTask<EntityEntry<TEntity>> AddAsync<TEntity>([NotNullAttribute] TEntity entity, CancellationToken cancellationToken = default) where TEntity : class;
        void AddRange([NotNullAttribute] IEnumerable<object> entities);
        void AddRange([NotNullAttribute] params object[] entities);
        Task AddRangeAsync([NotNullAttribute] IEnumerable<object> entities, CancellationToken cancellationToken = default);
        Task AddRangeAsync([NotNullAttribute] params object[] entities);
        void Dispose();
        ValueTask DisposeAsync();
        EntityEntry Remove([NotNullAttribute] object entity);
        EntityEntry<TEntity> Remove<TEntity>([NotNullAttribute] TEntity entity) where TEntity : class;
        void RemoveRange([NotNullAttribute] params object[] entities);
        void RemoveRange([NotNullAttribute] IEnumerable<object> entities);
        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        string ToString();
        EntityEntry Update([NotNullAttribute] object entity);
        EntityEntry<TEntity> Update<TEntity>([NotNullAttribute] TEntity entity) where TEntity : class;
        void UpdateRange([NotNullAttribute] params object[] entities);
        void UpdateRange([NotNullAttribute] IEnumerable<object> entities);
        object Entry(Charity charity);

        #endregion
    }
}
