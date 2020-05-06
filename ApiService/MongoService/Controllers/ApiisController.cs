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
    public class ApiisController : ControllerBase
    {
        private readonly ApiiRepository _repo;
        public ApiisController(ApiiRepository repo)
        {
            _repo = repo;
        }        
        // GET api/apiis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MongodbApii>>> Get()
        {
            return new ObjectResult(await _repo.GetAllApiis());
        }        
        // GET api/apiis/1
        [HttpGet("{id}")]
        public async Task<ActionResult<MongodbApii>> Get(long id)
        {
            var Apii = await _repo.GetApii(id); if (Apii == null)
                return new NotFoundResult();

            return new ObjectResult(Apii);
        }        
        // POST api/apiis
        [HttpPost]
        public async Task<ActionResult<MongodbApii>> Post([FromBody] MongodbApii Apii)
        {
            Apii.Id = await _repo.GetNextId();
            await _repo.Create(Apii);
            return new OkObjectResult(Apii);
        }        
        // PUT api/apiis/1
        [HttpPut("{id}")]
        public async Task<ActionResult<MongodbApii>> Put(long id, [FromBody] MongodbApii Apii)
        {
            var ApiiFromDb = await _repo.GetApii(id); if (ApiiFromDb == null)
                return new NotFoundResult(); Apii.Id = ApiiFromDb.Id;
            Apii.InternalId = ApiiFromDb.InternalId; await _repo.Update(Apii); return new OkObjectResult(Apii);
        }        
        // DELETE api/apiis/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var post = await _repo.GetApii(id); if (post == null)
                return new NotFoundResult(); await _repo.Delete(id); return new OkResult();
        }
    }
}
