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
    public class KittensController : ControllerBase
    {
        private readonly KittensEatingDessertsContext _context;

        public KittensController(KittensEatingDessertsContext context)
        {
            _context = context;
        }

        // GET: api/Kittens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kitten>>> GetKittens()
        {
          if (_context.Kittens == null)
          {
              return NotFound();
          }
            return await _context.Kittens.ToListAsync();
        }

        // GET: api/Kittens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kitten>> GetKitten(Guid id)
        {
          if (_context.Kittens == null)
          {
              return NotFound();
          }
            var kitten = await _context.Kittens.FindAsync(id);

            if (kitten == null)
            {
                return NotFound();
            }

            return kitten;
        }

        // PUT: api/Kittens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKitten(Guid id, Kitten kitten)
        {
            if (id != kitten.Id)
            {
                return BadRequest();
            }

            _context.Entry(kitten).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KittenExists(id))
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

        // POST: api/Kittens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Kitten>> PostKitten(Kitten kitten)
        {
          if (_context.Kittens == null)
          {
              return Problem("Entity set 'KittensEatingDessertsContext.Kittens'  is null.");
          }
            _context.Kittens.Add(kitten);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKitten", new { id = kitten.Id }, kitten);
        }

        // DELETE: api/Kittens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKitten(Guid id)
        {
            if (_context.Kittens == null)
            {
                return NotFound();
            }
            var kitten = await _context.Kittens.FindAsync(id);
            if (kitten == null)
            {
                return NotFound();
            }

            _context.Kittens.Remove(kitten);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KittenExists(Guid id)
        {
            return (_context.Kittens?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
