using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApi.Model.Models;
using VideoGameAPI.Repository.Contracts;
using VideoGameAPI.Repository.Core;
using VideoGameAPI.Service.Contracts;

namespace VideoGameAPI.Service
{
    public class VideoGameService : IVideoGameService
    {
        
        private readonly IVideoGameDAO _videoGameDAO;

        // => Dep injection : registered videoGameDAO gets injected into constructors params 
        public VideoGameService(IVideoGameDAO videoGameDAO)
        {
            _videoGameDAO = videoGameDAO;
        }

        public async Task<VideoGame> Get(int id)
        {
            return await _videoGameDAO.GetAsync(id);
        }



        public async Task<IEnumerable<VideoGame>> GetAll()
        {
            return await _videoGameDAO.GetAllAsync();
        }

        public async Task<VideoGame> AddAsync(VideoGame videoGame)
        {
            return await _videoGameDAO.AddAsync(videoGame);
        }

        public async Task<bool> RemoveAsync(int id)
        {
            return await _videoGameDAO.RemoveAsync(id);
        }
    }
}
