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
    public class DeveloperService : IDeveloperService
    {
        private readonly IDeveloperDAO _developerDAO;

        public DeveloperService(IDeveloperDAO developerDAO)
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

        public async Task<Developer> AddAsync(Developer developer)
        {
            // validatie en error afhandeling
            return await _developerDAO.AddAsync(developer);
        }

        public async Task<bool> RemoveAsync(int id)
        {
            return await _developerDAO.RemoveAsync(id);
        }
    }
}
