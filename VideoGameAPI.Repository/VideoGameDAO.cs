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
    public class VideoGameDAO : IDAO<VideoGame>
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

            } catch(InvalidOperationException ex) {
                throw new Exception($"Error in VideoGameDAO in getAsync method, element with id: {id} not found.");

            } catch{
                throw new Exception($"Error in VideoGameDAO in getAsync method while looking for record with id: {id}");
            }
            

        }
    }
}
