using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

using SlienGames.Data.Contracts;
using SlienGames.Data.Models.Contracts;

namespace SlienGames.Data
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ISlienGamesDbContext dbContext;
        private readonly IDbSet<TEntity> dbSet;

        public EfRepository(ISlienGamesDbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException($"{nameof(dbContext)} is null in DB context!");
            }

            this.dbContext = dbContext;
            this.dbSet = this.dbContext.Set<TEntity>();

            if (this.dbSet == null)
            {
                throw new ArgumentException($"DbContext does not contain DbSet<{nameof(TEntity)}>");
            }
        }

        public TEntity GetById(object id)
        {
            return this.dbSet.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this.GetAll(null);
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filterExpression)
        {
            return this.GetAll<object>(filterExpression, null);
        }

        public IEnumerable<TEntity> GetAll<T1>(Expression<Func<TEntity, bool>> filterExpression, Expression<Func<TEntity, T1>> sortExpression)
        {
            return this.GetAll<T1, TEntity>(filterExpression, sortExpression, null);
        }

        public IEnumerable<T2> GetAll<T1, T2>(Expression<Func<TEntity, bool>> filterExpression, Expression<Func<TEntity, T1>> sortExpression, Expression<Func<TEntity, T2>> selectExpression)
        {
            IQueryable<TEntity> result = this.dbSet;

            if (filterExpression != null)
            {
                result = result.Where(filterExpression);
            }

            if (sortExpression != null)
            {
                result = result.OrderBy(sortExpression);
            }

            if (selectExpression != null)
            {
                return result.Select(selectExpression).ToList();
            }
            else
            {
                return result.OfType<T2>().ToList();
            }
        }

        public void Add(TEntity entity)
        {
            var entry = AttachIfDetached(entity);
            entry.State = EntityState.Added;
        }

        public void Update(TEntity entity)
        {
            var entry = AttachIfDetached(entity);
            entry.State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            var entry = AttachIfDetached(entity);
            entry.State = EntityState.Deleted;
        }

        private DbEntityEntry AttachIfDetached(TEntity entity)
        {
            var entry = this.dbContext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.dbSet.Attach(entity);
            }

            return entry;
        }
    }
}
