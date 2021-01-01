using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GreenPoints.API.Models;

namespace GreenPoints.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GreenPointItemsController : ControllerBase
    {
        private readonly GreenPointContext _context;

        public GreenPointItemsController(GreenPointContext context)
        {
            _context = context;
        }

        // GET: api/GreenPointItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GreenPointItem>>> GetGreenPointItem()
        {
            return await _context.GreenPointItem.ToListAsync();
        }

        // GET: api/GreenPointItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GreenPointItem>> GetGreenPointItem(int id)
        {
            var greenPointItem = await _context.GreenPointItem.FindAsync(id);

            if (greenPointItem == null)
            {
                return NotFound();
            }

            return greenPointItem;
        }

        // PUT: api/GreenPointItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGreenPointItem(int id, GreenPointItem greenPointItem)
        {
            if (id != greenPointItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(greenPointItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GreenPointItemExists(id))
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

        // POST: api/GreenPointItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GreenPointItem>> PostGreenPointItem(GreenPointItem greenPointItem)
        {
            _context.GreenPointItem.Add(greenPointItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGreenPointItem), new { id = greenPointItem.Id }, greenPointItem);
        }

        // DELETE: api/GreenPointItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGreenPointItem(int id)
        {
            var greenPointItem = await _context.GreenPointItem.FindAsync(id);
            if (greenPointItem == null)
            {
                return NotFound();
            }

            _context.GreenPointItem.Remove(greenPointItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GreenPointItemExists(int id)
        {
            return _context.GreenPointItem.Any(e => e.Id == id);
        }
    }
}
