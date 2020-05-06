using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataCore.Model;
using StorageService.Context;

namespace StorageService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public LocationsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Locations
        [HttpGet]
        public IEnumerable<Location> GetLocations()
        {
            return _context.Locations;
        }

        // GET: api/Locations/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocation([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var location = await _context.Locations.FindAsync(id);

            if (location == null)
            {
                return NotFound();
            }

            return Ok(location);
        }

        // PUT: api/Locations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocation([FromRoute] long id, [FromBody] Location location)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != location.Id)
            {
                return BadRequest();
            }

            _context.Entry(location).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Locations
        [HttpPost]
        public async Task<IActionResult> PostLocation([FromBody] Location location)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Locations.Add(location);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocation", new { id = location.Id }, location);
        }

        // DELETE: api/Locations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var location = await _context.Locations.FindAsync(id);
            if (location == null)
            {
                return NotFound();
            }

            _context.Locations.Remove(location);
            await _context.SaveChangesAsync();

            return Ok(location);
        }

        private bool LocationExists(long id)
        {
            return _context.Locations.Any(e => e.Id == id);
        }
    }
}