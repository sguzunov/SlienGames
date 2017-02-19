using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SlienGames.Data.Contracts
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(object id);

        IQueryable<TEntity> All { get; }

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filterExpression);

        IEnumerable<TEntity> GetAll<T1>(Expression<Func<TEntity, bool>> filterExpression, Expression<Func<TEntity, T1>> selectExpression);

        IEnumerable<T2> GetAll<T1, T2>(Expression<Func<TEntity, bool>> filterExpression, Expression<Func<TEntity, T1>> sortExpression, Expression<Func<TEntity, T2>> selectExpression);

        void Add(TEntity entity);

        void Update(TEntity entity);
    }
}
