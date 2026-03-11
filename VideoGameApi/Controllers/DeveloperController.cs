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

        private readonly IDeveloperService _developerService;

        public DeveloperController(IDeveloperService developerService)
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

        [HttpPost]
        public async Task<ActionResult<Developer>> AddDeveloper(Developer developer)
        {
            try
            {
                if(developer is null)
                {
                    return BadRequest("Developer data is missing."); 
                }
                // als data niet correct is => UnprocessableEntity

                var dev = await _developerService.AddAsync(developer);
                return dev; 

            } catch (Exception ex)
            {


                // ongekende error doet zich voor => internal server error
                return StatusCode(500, "An internal server error has occured");
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteDeveloper(int id)
        {
            try
            {
                bool deleted = await _developerService.RemoveAsync(id);
                return deleted ? NoContent() : NotFound("Developer with given Id not found");

            } catch (Exception ex)
            {
                return StatusCode(500, "An internal server error has occured");
            }
        }

        

    }
}
