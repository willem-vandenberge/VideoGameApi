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
    public class VideoGameService : IService<VideoGame>
    {
        
        private readonly IDAO<VideoGame> _videoGameDAO;

        // => Dep injection : registered videoGameDAO gets injected into constructors params 
        public VideoGameService(IDAO<VideoGame> videoGameDAO)
        {
            _videoGameDAO = videoGameDAO;
        }

        public async Task<VideoGame> Get(int id)
        {
            //throw new NotImplementedException();

            return await _videoGameDAO.GetAsync(id);
        }



        public Task<IEnumerable<VideoGame>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
