using System.Collections.Generic;

namespace ApplicationCore.Interfaces.RepositoryInterfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetByID(object id);
        void Insert(TEntity entity);
        void DeleteByid(object id);
        void Delete(TEntity entityToDelete);
        void Update(TEntity entityToUpdate);
    }
}