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
    public class BatteriesController : ControllerBase
    {
        private readonly BatteryRepository _repo;
        public BatteriesController(BatteryRepository repo)
        {
            _repo = repo;
        }        
        // GET api/batteries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MongodbBattery>>> Get()
        {
            return new ObjectResult(await _repo.GetAllBatteries());
        }        
        // GET api/batteries/1
        [HttpGet("{id}")] 
        public async Task<ActionResult<MongodbBattery>> Get(long id)
        {
            var Battery = await _repo.GetBattery(id); if (Battery == null)
                return new NotFoundResult();

            return new ObjectResult(Battery);
        }        
        // POST api/batteries
        [HttpPost]
        public async Task<ActionResult<MongodbBattery>> Post([FromBody] MongodbBattery Battery)
        {
            Battery.Id = await _repo.GetNextId();
            await _repo.Create(Battery);
            return new OkObjectResult(Battery);
        }        
        // PUT api/batteries/1
        [HttpPut("{id}")]
        public async Task<ActionResult<MongodbBattery>> Put(long id, [FromBody] MongodbBattery Battery)
        {
            var BatteryFromDb = await _repo.GetBattery(id); if (BatteryFromDb == null)
                return new NotFoundResult(); Battery.Id = BatteryFromDb.Id;
            Battery.InternalId = BatteryFromDb.InternalId; await _repo.Update(Battery); return new OkObjectResult(Battery);
        }        
        // DELETE api/batteries/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var post = await _repo.GetBattery(id); if (post == null)
                return new NotFoundResult(); await _repo.Delete(id); return new OkResult();
        }
    }
}
