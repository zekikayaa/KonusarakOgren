using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TestApp.DAL.Repositories.Abstract;
using TestApp.Domains.Domains;


namespace TestApp.DAL.Repositories.Concrete
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected DbContext _dbContext;
        private DbSet<TEntity> _dbSet;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _dbSet.AddRange(entity);
            _dbContext.SaveChanges();
        }

        public void AddRaange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            _dbContext.SaveChanges();
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return query;
        }

        public void Update(TEntity entitiy)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }
    }
}
