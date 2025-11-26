using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoGameApi.Model.Models;
using VideoGameAPI.Service.Contracts;
using VideoGameAPI.Service;
using System.Threading.Tasks;

namespace VideoGameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController : ControllerBase
    {

        private readonly IService<VideoGame> _videoGameService;

        // "oude manier" => vanaf c#12 kan je gebruik maken van primary constructor ook
        // géén primary constructor is overzichtelijker... 
        public VideoGameController(IService<VideoGame> videoGameService)
        {
            _videoGameService = videoGameService;
        }

        [HttpGet]
        public async Task<ActionResult<List<VideoGame>>> GetVideoGames()
        {
            try
            {
                var videoGames = await _videoGameService.GetAll();
                return Ok(videoGames);
            } catch ( Exception e)
            {
                return NotFound();
            }
        }

        // Route specifiëren obv id die we willen ophalen kan met [Route("{id}")]
        // of combineren in HttpGet zoals hieronder
        [HttpGet("{id}")]
        public async Task<ActionResult<VideoGame>> GetVideoGameById(int id)
        {
            var game = await _videoGameService.Get(id);
            if (game is null)
                return NotFound(); // 404 id niet gevonden
            return Ok(game);
        }

        /**
         * Videogame aanmaken. 
         * Nieuwe videogame wordt geretourneerd ook
         */
        //[HttpPost]
        //public ActionResult<VideoGame> AddVideoGame(VideoGame newGame)
        //{
        //    if (newGame is null)
        //        return BadRequest();

        //    // Max functie gebruiken om de hoogste Id op te halen
        //    newGame.Id = videoGames.Max(g => g.Id) + 1;
        //    videoGames.Add(newGame);

        //    return CreatedAtAction(nameof(GetVideoGameById), new { id = newGame.Id }, newGame);
        //}

        /**
         * Update method
         * "put" - endpoint that can update the complete object
         * "patch" - endpoint die misschien maar 1 property updates
         * 
         * put vereist de bestaande id van een object
         */
        //[HttpPut("{id}")]
        //public IActionResult UpdateVideoGame(int id, VideoGame updateGame)
        //{
        //    var game = videoGames.FirstOrDefault(g => g.Id == id);
        //    if (game is null)
        //        return NotFound(); // id komt niet overeen met bestaand object

        //    game.Title = updateGame.Title;
        //    game.Platform = updateGame.Platform;
        //    game.Developer = updateGame.Developer;
        //    game.Publisher = updateGame.Publisher;

        //    return NoContent(); // Succesvol
        //}

        /**
         * Delete method
         */
        //[HttpDelete("{id}")]
        //public IActionResult DeleteVideoGame(int id)
        //{
        //    var game = videoGames.FirstOrDefault(g => g.Id == id);
        //    if (game is null)
        //        return NotFound(); // 404 videogame bestaat niet

        //    videoGames.Remove(game);

        //    return NoContent();
        //}


    }

    
}
