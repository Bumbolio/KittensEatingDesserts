namespace KittensEatingDesserts.Models
{
    public class Breed
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string? Description { get; set; }
        public int HairLengthIn { get; set; }
        public bool IsPurrBread { get; set; }
        public int LengthInIn { get; set; }
        public int LifeExpectancyYears { get; set; }
    }
}
