using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using DataCore.Model;
using ApiService.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatteryController : ControllerBase
    {
        private readonly IBatteryRepository _batteryRepository;

        public BatteryController(IBatteryRepository batteryRepository)
        {
            _batteryRepository = batteryRepository;
        }
        // GET: api/Battery
        [HttpGet]
        public IActionResult Get()
        {
            var batteries = _batteryRepository.GetBatteries();
            return new OkObjectResult(batteries);
        }

        // GET: api/Battery/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var battery = _batteryRepository.GetBatteryByID(id);
            return new OkObjectResult(battery);
        }

        // POST: api/Battery
        [HttpPost]
        public IActionResult Post([FromBody] Battery battery)
        {
            using (var scope = new TransactionScope())
            {
                _batteryRepository.InsertBattery(battery);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = battery.Id }, battery);
            }
        }

        // PUT: api/Battery/5
        [HttpPut]
        public IActionResult Put([FromBody] Battery battery)
        {
            if (battery != null)
            {
                using (var scope = new TransactionScope())
                {
                    _batteryRepository.UpdateBattery(battery);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _batteryRepository.DeleteBattery(id);
            return new OkResult();
        }
    }
}
