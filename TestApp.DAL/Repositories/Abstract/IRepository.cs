using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TestApp.Domains.Domains;

namespace TestApp.DAL.Repositories.Abstract
{
    public interface IRepository<TEntity> 
    {
        TEntity GetById(int id);

        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

        IQueryable<TEntity> QueryWithInclude(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params string[] includes);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetAllWithIncluding(params string[] includes);

        void Add(TEntity entity);

        void AddRaange(IEnumerable<TEntity> entities);

        void Update(TEntity entitiy);


        void UpdateRange(IEnumerable<TEntity> entities);


        void Delete(int id);

        void Delete(TEntity entity);

        void DeleteRange(IEnumerable<TEntity> entities);

    }
}
