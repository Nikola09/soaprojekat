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
    public class BatteriesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public BatteriesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Batteries
        [HttpGet]
        public IEnumerable<Battery> GetBatteries()
        {
            return _context.Batteries;
        }

        // GET: api/Batteries/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBattery([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var battery = await _context.Batteries.FindAsync(id);

            if (battery == null)
            {
                return NotFound();
            }

            return Ok(battery);
        }

        // PUT: api/Batteries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBattery([FromRoute] long id, [FromBody] Battery battery)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != battery.Id)
            {
                return BadRequest();
            }

            _context.Entry(battery).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BatteryExists(id))
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

        // POST: api/Batteries
        [HttpPost]
        public async Task<IActionResult> PostBattery([FromBody] Battery battery)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Batteries.Add(battery);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBattery", new { id = battery.Id }, battery);
        }

        // DELETE: api/Batteries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBattery([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var battery = await _context.Batteries.FindAsync(id);
            if (battery == null)
            {
                return NotFound();
            }

            _context.Batteries.Remove(battery);
            await _context.SaveChangesAsync();

            return Ok(battery);
        }

        private bool BatteryExists(long id)
        {
            return _context.Batteries.Any(e => e.Id == id);
        }
    }
}