using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameAPI.Repository.Contracts
{
    public interface IDAO<TEntity> where TEntity: class
    {
        Task<TEntity> GetAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        //IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        //void Add(TEntity entity);
        //void AddRange(IEnumerable<TEntity> entities);

        //void Remove(TEntity entity);
        //void RemoveRange(IEnumerable<TEntity> entities);

    }
}
