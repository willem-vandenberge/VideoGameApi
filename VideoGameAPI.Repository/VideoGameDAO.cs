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
    public class VideoGameDAO : IVideoGameDAO
    {
        private readonly VideoGameDBContext _context;

        public VideoGameDAO(VideoGameDBContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<VideoGame>> GetAllAsync()
        {
            try
            {
                var videoGames = await _context.VideoGames
                    .ToListAsync();
                return videoGames;

            } catch ( Exception e)
            {
                throw new Exception($"An Error in VideoGameDAO in GetAllAsync method with message: {e.Message}.");
            }
        }

        public async Task<VideoGame> GetAsync(int id)
        {
            try {
                // First() => exception indien niks gevonden dat aan conditie voldoet
                // FirstOrDefault() => returns null indien nietts aan conditie voldoet
                return await _context.VideoGames
                    .Where(v => v.Id == id) // where clause weglaten? 
                    .FirstAsync();

            } catch(InvalidOperationException ioex) {
                throw new Exception($"Error in VideoGameDAO in getAsync method, element with id: {id} not found.", ioex);

            } catch (Exception ex){
                throw new Exception($"Error in VideoGameDAO in getAsync method while looking for record with id: {id}", ex);
            }
            

        }

        public async Task<VideoGame> AddAsync(VideoGame entity)
        {
            try
            {
                if(entity is null)
                {
                    throw new ArgumentNullException("The entity does not contain a value");
                }

                _context.VideoGames.Add(entity);
                await _context.SaveChangesAsync();
                return entity;

            } catch (Exception ex)
            {
                throw new Exception($"Error in VideoGameDAO in AddAsync method", ex);
            }
        }

        public async Task<bool> RemoveAsync(int id)
        {
            try
            {
                var videoGameToDelete = await _context.VideoGames.FindAsync(id);
                if (videoGameToDelete is null)
                {
                    return false;
                }

                // remove methode begint 'tracking'
                _context.VideoGames.Remove(videoGameToDelete);
                // save changes voert de commando's uit
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception($"Error in VideoGameDAO in RemoveAsync method", ex);
            }
        
        }

        public async Task<VideoGame> UpdateAsync(int id, VideoGame videoGameChanges)
        {
            try
            {
                throw new NotImplementedException();
            } catch (Exception ex)
            {
                throw new Exception($"An Error in VideoGameDAO in GetAllAsync method with message: {ex.Message}.", ex);

            }
        }
    }
}
