using System.Collections.Generic;
using TestApp.Domains.Domains;

namespace TestApp.DAL.Repositories.Abstract
{
    public interface IRepository<TEntity> 
    {
        TEntity GetById(int id);

        IEnumerable<TEntity> GetAll();

        void Add(TEntity entity);

        void AddRaange(IEnumerable<TEntity> entities);

        void Update(TEntity entitiy);


        void UpdateRange(IEnumerable<TEntity> entities);


        void Delete(int id);

        void Delete(TEntity entity);

        void DeleteRange(IEnumerable<TEntity> entities);

    }
}
