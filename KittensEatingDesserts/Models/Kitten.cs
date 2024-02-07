using KittensEatingDesserts.Classes;

namespace KittensEatingDesserts.Models
{
    public class Kitten
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public ICollection<Color>? Colors { get; set; }
        public int? LivesRemaining { get; set; }
        public Breed? Breed { get; set; }
        public Dessert? FavoriteDessert { get; set; }

        //Favorite Dessert
       
    }
}
