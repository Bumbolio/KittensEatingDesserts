using KittensEatingDesserts.Classes;

namespace KittensEatingDesserts.Models
{
    public class Rating
    {
        public Guid Id { get; set; }
        public RatingScale AssignedRating { get; set; }

        public ICollection<Dessert> Desserts { get; set; }
    }
}
