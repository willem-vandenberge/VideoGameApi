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

        public Task<IEnumerable<VideoGame>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<VideoGame> GetAsync(int id)
        {
            try
            {
                // ipv firstordefault FirstAsync?  => firstordefault geeft null indien niet gevonden
                var game = await _context.VideoGames
                    .Where(v => v.Id == id) // where closule nodig? 
                    .FirstOrDefaultAsync();
                //var game = await _context.VideoGames.FirstOrDefaultAsync(v => v.Id == id);

                return game is null ? throw new Exception() : game;
            }
            catch
            {
                throw new Exception($"Error in VideoGameDAO in getAsync method while looking for record with id: {id}");
            }
            

        }
    }
}
