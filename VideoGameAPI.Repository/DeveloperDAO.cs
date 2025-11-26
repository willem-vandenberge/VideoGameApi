using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApi.Model.Models;
using VideoGameAPI.Repository.Contracts;
using VideoGameAPI.Repository.Core;

namespace VideoGameAPI.Repository
{
    public class DeveloperDAO : IDAO<Developer>
    {
        private readonly VideoGameDBContext _context;

        public DeveloperDAO(VideoGameDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Developer>> GetAllAsync()
        {
            try{
                var developers = await _context.Developers
                    .ToListAsync();
                return developers;
            }
            catch (Exception e) {
                throw new Exception($"An Error in DeveloperDAO in GetAllAsync method with message: {e.Message}.");
            }
        }

        public async Task<Developer> GetAsync(int id)
        {
            try
            {
                return await _context.Developers
                    .Where(d => d.Id == id)
                    .FirstAsync();
            } catch(InvalidOperationException ex)
            {
                // id niet gevonden
                throw new Exception($"Error in DeveloperDAO in getAsync method, item with id: {id} not found.");
            } catch(Exception e)
            {
                throw new Exception($"An Error in DeveloperDAO in GetAsync method with message: {e.Message}.");

            }
        }
    }
}
