using KittensEatingDesserts.Classes;
using KittensEatingDesserts.Data;
using KittensEatingDesserts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KittensEatingDesserts.Controllers
{
    [Route("api/Desserts/{dessertId}/Ratings")]
    [ApiController]
    public class DessertRatings : ControllerBase
    {
        private readonly KittensEatingDessertsContext _context;

        public DessertRatings(KittensEatingDessertsContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public async Task<List<Rating>> GetDessertRatings(Guid dessertId) 
        {
            var ratings = _context.Ratings
                .Include(rating => rating.Dessert)
                .Where(rating => rating.DessertId == dessertId).ToList();

            return ratings;
            
        }

        [HttpGet]
        [Route("Average")]
        public async Task<AverageRating> GetDessertRatingsAverage(Guid dessertId)
        {
            var average = _context.Ratings
                .Include(rating => rating.Dessert)
                .Where(rating => rating.DessertId == dessertId)
                .Average(rating => (double)rating.AssignedRating);

            var result = new AverageRating
            {
                Average = average
            };

            return result;

        }

        [HttpGet]
        [Route("{ratingId}")]
        public async Task<Rating> GetDessertRatings(Guid dessertId, Guid ratingId)
        {
            var rating = await _context.Ratings
                .Include(rating => rating.Dessert)
                .Where(rating => rating.DessertId == dessertId && rating.Id == ratingId)
                .FirstOrDefaultAsync();

            return rating;

        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Dessert>> PostDessertRating(Guid dessertId, Rating rating)
        {
            if (_context.Desserts == null)
            {
                return Problem("Entity set 'KittensEatingDessertsContext.Desserts'  is null.");
            }
            _context.Ratings.Add(rating);
            await _context.SaveChangesAsync();

            return Ok();
            //return CreatedAtAction("GetDessertRatings", new { id = rating.DessertId }, rating);
        }
    }
}
