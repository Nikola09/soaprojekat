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
    public class ApiisController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ApiisController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Apiis
        [HttpGet]
        public IEnumerable<Apii> GetApiis()
        {
            return _context.Apiis;
        }

        // GET: api/Apiis/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetApii([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var apii = await _context.Apiis.FindAsync(id);

            if (apii == null)
            {
                return NotFound();
            }

            return Ok(apii);
        }

        // PUT: api/Apiis/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApii([FromRoute] long id, [FromBody] Apii apii)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != apii.Id)
            {
                return BadRequest();
            }

            _context.Entry(apii).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApiiExists(id))
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

        // POST: api/Apiis
        [HttpPost]
        public async Task<IActionResult> PostApii([FromBody] Apii apii)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Apiis.Add(apii);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApii", new { id = apii.Id }, apii);
        }

        // DELETE: api/Apiis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApii([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var apii = await _context.Apiis.FindAsync(id);
            if (apii == null)
            {
                return NotFound();
            }

            _context.Apiis.Remove(apii);
            await _context.SaveChangesAsync();

            return Ok(apii);
        }

        private bool ApiiExists(long id)
        {
            return _context.Apiis.Any(e => e.Id == id);
        }
    }
}