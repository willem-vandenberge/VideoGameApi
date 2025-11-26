using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoGameApi.Model.Models;
using VideoGameAPI.Service;
using VideoGameAPI.Service.Contracts;

namespace VideoGameApi.Controllers
{
    // naam controller mappen
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {

        private readonly IService<Developer> _developerService;

        public DeveloperController(IService<Developer> developerService)
        {
            _developerService = developerService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Developer>> GetDeveloperById(int id)
        {
            try
            {
                var developer = await _developerService.Get(id);
                // 404: developer met id niet teruggevonden
                if (developer is null)
                    return NotFound();

                return Ok(developer);
            } catch(Exception e)
            {
                //
                return NotFound();
            }
            
        }

        // get all developers, geen extra path toevoegen
        [HttpGet]
        public async Task<ActionResult<List<Developer>>> GetDevelopers()
        {
            try
            {
                var developers = await _developerService.GetAll();
                return Ok(developers);

            } catch(Exception e) {
                // should get return notfound when list is empty/error handling
                return NotFound();
            }
        }

        

    }
}
