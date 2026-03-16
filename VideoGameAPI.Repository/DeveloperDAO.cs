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
    public class DeveloperDAO : IDeveloperDAO
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

        public async Task<Developer> AddAsync(Developer entity)
        {
            try
            {
                if( entity is null)
                {
                    throw new ArgumentNullException("The entity does not contain a value");
                }

                // TODO : validation for entity

                // Entiteit toevoegen aan de context
                _context.Developers.Add(entity);

                // De wijzigingen opslaan in de database
                await _context.SaveChangesAsync();

                // Nadat SaveChangesAsync is uitgevoerd, heeft 'entity' automatisch het nieuwe ID gekregen van de dbs
                // entity met nieuwe id retourneren 
                return entity;

            } catch (Exception ex)
            {
                throw new Exception($"An Error in DeveloperDAO AddAsync method with message: {ex.Message}");
            }
        }

        public async Task<bool> RemoveAsync(int id)
        {
            try
            {
                var devToDelete = await _context.Developers.FindAsync(id);
                if (devToDelete is null)
                {
                    return false;
                }

                _context.Developers.Remove(devToDelete);
                await _context.SaveChangesAsync();

                return true;

            } catch (Exception ex)
            {
                throw new Exception("Error from delete method in DeveloperDAO", ex);
            }
            
        }

        public async Task<Developer> UpdateAsync(int id, Developer developerChanges)
        {
            try
            {
                throw new NotImplementedException();

            } catch (Exception ex)
            {
                throw new Exception($"An Error in DeveloperDAO UpdateAsync method with message: {ex.Message}", ex);

            }
        }
    }
}
