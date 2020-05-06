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
    public class AmbientsController : ControllerBase
    {
        private readonly AmbientRepository _repo;
        public AmbientsController(AmbientRepository repo)
        {
            _repo = repo;
        }        
        // GET api/ambients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MongodbAmbient>>> Get()
        {
            return new ObjectResult(await _repo.GetAllAmbients());
        }        
        // GET api/ambients/1
        [HttpGet("{id}")]
        public async Task<ActionResult<MongodbAmbient>> Get(long id)
        {
            var Ambient = await _repo.GetAmbient(id); if (Ambient == null)
                return new NotFoundResult();

            return new ObjectResult(Ambient);
        }        
        // POST api/ambients
        [HttpPost]
        public async Task<ActionResult<MongodbAmbient>> Post([FromBody] MongodbAmbient Ambient)
        {
            Ambient.Id = await _repo.GetNextId();
            await _repo.Create(Ambient);
            return new OkObjectResult(Ambient);
        }        
        // PUT api/ambients/1
        [HttpPut("{id}")]
        public async Task<ActionResult<MongodbAmbient>> Put(long id, [FromBody] MongodbAmbient Ambient)
        {
            var AmbientFromDb = await _repo.GetAmbient(id); if (AmbientFromDb == null)
                return new NotFoundResult(); Ambient.Id = AmbientFromDb.Id;
            Ambient.InternalId = AmbientFromDb.InternalId; await _repo.Update(Ambient); return new OkObjectResult(Ambient);
        }        
        // DELETE api/ambients/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var post = await _repo.GetAmbient(id); if (post == null)
                return new NotFoundResult(); await _repo.Delete(id); return new OkResult();
        }
    }
}
