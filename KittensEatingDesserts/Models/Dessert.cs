using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace KittensEatingDesserts.Models
{
    public class Dessert
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public int Calories { get; set; }
        public bool IsWarm { get; set; }
        [NotMapped]
        public bool IsCold
        {
            get
            {
                return !IsWarm;
            }
        }
        public bool IsDry { get; set; }
        [NotMapped]
        public bool IsWet
        {
            get
            {
                return !IsDry;
            }
        }

        [NotMapped]
        public double? AverageRating
        {
            get
            {
                return this.Ratings?.Average(rating => (double)rating.AssignedRating);
            }
        }

        [JsonIgnore]
        public ICollection<Rating> Ratings { get; set; }

    }
}
