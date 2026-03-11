using System.Linq.Expressions;
using VideoGameAPI.Repository.Contracts;
using VideoGameAPI.Repository.Core;

namespace VideoGameAPI.Repository.Core
{
    public class Repository<TEntity> : IDAO<TEntity> where TEntity : class
    {
        private readonly VideoGameDBContext _context;

        public Repository(VideoGameDBContext context)
        {
            _context = context;
        }

        public Task<TEntity> AddAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpdateAsync(int id, TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
