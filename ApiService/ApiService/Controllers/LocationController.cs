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
    public class LocationController : ControllerBase
    {
        private readonly ILocationRepository _locationRepository;

        public LocationController(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }
        // GET: api/Location
        [HttpGet]
        public IActionResult Get()
        {
            var locations = _locationRepository.GetLocations();
            return new OkObjectResult(locations);
        }

        // GET: api/Location/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var location = _locationRepository.GetLocationByID(id);
            return new OkObjectResult(location);
        }

        // POST: api/Location
        [HttpPost]
        public IActionResult Post([FromBody] Location location)
        {
            using (var scope = new TransactionScope())
            {
                _locationRepository.InsertLocation(location);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = location.Id }, location);
            }
        }

        // PUT: api/Location/5
        [HttpPut]
        public IActionResult Put([FromBody] Location location)
        {
            if (location != null)
            {
                using (var scope = new TransactionScope())
                {
                    _locationRepository.UpdateLocation(location);
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
            _locationRepository.DeleteLocation(id);
            return new OkResult();
        }

    }
}
