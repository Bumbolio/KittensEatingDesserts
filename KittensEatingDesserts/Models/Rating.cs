using KittensEatingDesserts.Classes;
using System.ComponentModel.DataAnnotations.Schema;

namespace KittensEatingDesserts.Models
{
    public class Rating
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public RatingScale AssignedRating { get; set; }
        public Guid DessertId { get; set; }
        public Dessert? Dessert { get; set; }
    }
}
