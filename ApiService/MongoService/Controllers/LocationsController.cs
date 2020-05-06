using Microsoft.AspNetCore.Mvc;
using MongoService.Models;
using MongoService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly LocationRepository _repo;
        public LocationsController(LocationRepository repo)
        {
            _repo = repo;
        }        
        // GET api/Locations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MongodbLocation>>> Get()
        {
            return new ObjectResult(await _repo.GetAllLocations());
        }        
        // GET api/Locations/1
        [HttpGet("{id}")]
        public async Task<ActionResult<MongodbLocation>> Get(long id)
        {
            var Location = await _repo.GetLocation(id); if (Location == null)
                return new NotFoundResult();

            return new ObjectResult(Location);
        }        
        // POST api/Locations
        [HttpPost]
        public async Task<ActionResult<MongodbLocation>> Post([FromBody] MongodbLocation Location)
        {
            Location.Id = await _repo.GetNextId();
            await _repo.Create(Location);
            return new OkObjectResult(Location);
        }       
        // PUT api/Locations/1
        [HttpPut("{id}")]
        public async Task<ActionResult<MongodbLocation>> Put(long id, [FromBody] MongodbLocation Location)
        {
            var LocationFromDb = await _repo.GetLocation(id); if (LocationFromDb == null)
                return new NotFoundResult(); Location.Id = LocationFromDb.Id;
            Location.InternalId = LocationFromDb.InternalId; await _repo.Update(Location); return new OkObjectResult(Location);
        }        
        // DELETE api/Locations/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var post = await _repo.GetLocation(id); if (post == null)
                return new NotFoundResult(); await _repo.Delete(id); return new OkResult();
        }
    }
}
