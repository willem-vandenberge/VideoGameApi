using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameAPI.Service.Contracts
{
    /**
     * Contract for every service class.
     */
    public interface IService<TEntity> where TEntity : class
    {
        Task<TEntity> Get(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> AddAsync(TEntity entity);
        Task<bool> RemoveAsync(int id);

    }
}
