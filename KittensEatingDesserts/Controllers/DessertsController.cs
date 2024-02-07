using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KittensEatingDesserts.Data;
using KittensEatingDesserts.Models;

namespace KittensEatingDesserts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DessertsController : ControllerBase
    {
        private readonly KittensEatingDessertsContext _context;

        public DessertsController(KittensEatingDessertsContext context)
        {
            _context = context;
        }

        // GET: api/Desserts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dessert>>> GetDesserts()
        {
          if (_context.Desserts == null)
          {
              return NotFound();
          }
            return await _context.Desserts.ToListAsync();
        }

        // GET: api/Desserts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dessert>> GetDessert(Guid id)
        {
          if (_context.Desserts == null)
          {
              return NotFound();
          }
            var dessert = await _context.Desserts.FindAsync(id);

            if (dessert == null)
            {
                return NotFound();
            }

            return dessert;
        }

        // PUT: api/Desserts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDessert(Guid id, Dessert dessert)
        {
            if (id != dessert.Id)
            {
                return BadRequest();
            }

            _context.Entry(dessert).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DessertExists(id))
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

        // POST: api/Desserts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dessert>> PostDessert(Dessert dessert)
        {
          if (_context.Desserts == null)
          {
              return Problem("Entity set 'KittensEatingDessertsContext.Desserts'  is null.");
          }
            _context.Desserts.Add(dessert);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDessert", new { id = dessert.Id }, dessert);
        }

        // DELETE: api/Desserts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDessert(Guid id)
        {
            if (_context.Desserts == null)
            {
                return NotFound();
            }
            var dessert = await _context.Desserts.FindAsync(id);
            if (dessert == null)
            {
                return NotFound();
            }

            _context.Desserts.Remove(dessert);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DessertExists(Guid id)
        {
            return (_context.Desserts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
