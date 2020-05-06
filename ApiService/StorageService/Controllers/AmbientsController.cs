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
    public class AmbientsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public AmbientsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Ambients
        [HttpGet]
        public IEnumerable<Ambient> GetAmbients()
        {
            return _context.Ambients;
        }

        // GET: api/Ambients/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAmbient([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ambient = await _context.Ambients.FindAsync(id);

            if (ambient == null)
            {
                return NotFound();
            }

            return Ok(ambient);
        }

        // PUT: api/Ambients/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAmbient([FromRoute] long id, [FromBody] Ambient ambient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ambient.Id)
            {
                return BadRequest();
            }

            _context.Entry(ambient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AmbientExists(id))
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

        // POST: api/Ambients
        [HttpPost]
        public async Task<IActionResult> PostAmbient([FromBody] Ambient ambient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Ambients.Add(ambient);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAmbient", new { id = ambient.Id }, ambient);
        }

        // DELETE: api/Ambients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAmbient([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ambient = await _context.Ambients.FindAsync(id);
            if (ambient == null)
            {
                return NotFound();
            }

            _context.Ambients.Remove(ambient);
            await _context.SaveChangesAsync();

            return Ok(ambient);
        }

        private bool AmbientExists(long id)
        {
            return _context.Ambients.Any(e => e.Id == id);
        }
    }
}