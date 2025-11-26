using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoGameApi.Model.Models;

namespace VideoGameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        static private List<Developer> developers = new List<Developer> {
                new Developer
                {
                     Id = 1,
                    FirstName = "Melliw",
                    LastName = "De la Montange"
                },
                new Developer
                {
                     Id = 2,
                    FirstName = "Alexander",
                    LastName = "De la Mer"
                },
                new Developer
                {
                     Id = 3,
                    FirstName = "Mik",
                    LastName = "Treaccab"
                }
            };

        [HttpGet]
        public ActionResult<List<Developer>> GetDevelopers()
        {
            return Ok(developers);
        }

        [HttpGet("{id}")]
        public ActionResult<Developer> GetDeveloperById(int id)
        {
            var developer = developers.FirstOrDefault(d => d.Id == id);
            // 404: developer met id niet teruggevonden
            if (developer is null)
                return NotFound();

            return Ok(developer);
        }

    }
}
