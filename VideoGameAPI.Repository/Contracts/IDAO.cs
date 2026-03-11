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

        Task<TEntity> AddAsync(TEntity entity);

        //void AddRange(IEnumerable<TEntity> entities);

        Task<TEntity> UpdateAsync(int id, TEntity entity);

        Task<bool> RemoveAsync(int id);
        //void RemoveRange(IEnumerable<TEntity> entities);

    }
}
