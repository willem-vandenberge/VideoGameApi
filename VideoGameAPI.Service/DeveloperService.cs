using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApi.Model.Models;
using VideoGameAPI.Repository.Contracts;
using VideoGameAPI.Service.Contracts;

namespace VideoGameAPI.Service
{
    public class DeveloperService : IService<Developer>
    {
        private readonly IDAO<Developer> _developerDAO;

        public DeveloperService(IDAO<Developer> developerDAO)
        {
            _developerDAO = developerDAO;
        }


        public async Task<Developer> Get(int id)
        {
            return await _developerDAO.GetAsync(id);
        }

        public async Task<IEnumerable<Developer>> GetAll()
        {
            return await _developerDAO.GetAllAsync();
        }
    }
}
