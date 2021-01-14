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
    public class GreenPointUserItemsController : ControllerBase
    {
        private readonly GreenPointContext _context;

        public GreenPointUserItemsController(GreenPointContext context)
        {
            _context = context;
        }

        // GET: api/GreenPointUserItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GreenPointUserItem>>> GetGreenPointUserItem()
        {
            return await _context.GreenPointUserItem.ToListAsync();
        }

        // GET: api/GreenPointUserItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GreenPointUserItem>> GetGreenPointUserItem(int id)
        {
            var greenPointUserItem = await _context.GreenPointUserItem.FindAsync(id);

            if (greenPointUserItem == null)
            {
                return NotFound();
            }

            return greenPointUserItem;
        }

        // PUT: api/GreenPointUserItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGreenPointUserItem(int id, GreenPointUserItem greenPointUserItem)
        {
            if (id != greenPointUserItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(greenPointUserItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GreenPointUserItemExists(id))
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

        // POST: api/GreenPointUserItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GreenPointUserItem>> PostGreenPointUserItem(GreenPointUserItem greenPointUserItem)
        {
            _context.GreenPointUserItem.Add(greenPointUserItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGreenPointUserItem), new { id = greenPointUserItem.Id }, greenPointUserItem);
        }

        // DELETE: api/GreenPointUserItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGreenPointUserItem(int id)
        {
            var greenPointUserItem = await _context.GreenPointUserItem.FindAsync(id);
            if (greenPointUserItem == null)
            {
                return NotFound();
            }

            _context.GreenPointUserItem.Remove(greenPointUserItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GreenPointUserItemExists(int id)
        {
            return _context.GreenPointUserItem.Any(e => e.Id == id);
        }
    }
}
