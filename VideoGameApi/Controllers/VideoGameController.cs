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

        private readonly IVideoGameService _videoGameService;

        // "oude manier" => vanaf c#12 kan je gebruik maken van primary constructor ook
        // een bijkomend voordeel? is dat ook het veld _videoGameService kan weggelaten worden.
        // => de scope van een 'veld' uit een primary constructor is de volledige klasse. 
        // => bij een klasse is dit veld mutable (bij een record niet)
        // géén primary constructor is overzichtelijker... 
        // public class VideoGameController(IVideoGameService videoGameService) : ControllerBase
        public VideoGameController(IVideoGameService videoGameService)
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

        [HttpPost]
        public async Task<ActionResult<VideoGame>> AddVideoGame(VideoGame videoGame)
        {
            try
            {
                if (videoGame is null)
                {
                    return BadRequest("VideoGame data not found");
                }

                var savedVideoGame = await _videoGameService.AddAsync(videoGame);

                // met createdAtAction retourneren we 201 ok en voegen we de location header toe
                // die de client exact laat weten waar het nieuwe item kan gevonden worden
                // => nameof is veiliger en minder foutgevoelig dan een gewone string
                return CreatedAtAction(
                    actionName: nameof(GetVideoGameById),       
                    routeValues: new { id = savedVideoGame.Id},
                    value: savedVideoGame
                 );

            } catch (Exception ex)
            {
                return StatusCode(500, "An internal server error has occured.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVideoGame(int id)
        {
            try
            {
                var deleted = await _videoGameService.RemoveAsync(id);
                return deleted ? NoContent() : NotFound("Videogame with given Id not found.");

            } catch (Exception ex)
            {
                return StatusCode(500, "An internal server has occured");
            }
        }



    }

    
}
