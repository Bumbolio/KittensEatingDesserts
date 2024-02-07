using KittensEatingDesserts.Classes;
using KittensEatingDesserts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;

namespace KittensEatingDesserts.Data
{
    public class KittensEatingDessertsContext : DbContext
    {
        public DbSet<Kitten> Kittens { get; set; }
        public DbSet<Dessert> Desserts { get; set; }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Color> Colors { get; set; }


        public string DbPath { get; }

        public KittensEatingDessertsContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "kittensEatingDesserts.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Breed>().HasData(new Breed { 
                Name = "Maine Coon", 
                Description = "Gianormous Cat with big paws.", 
                HairLengthIn = 3,
                IsPurrBread = true,
                LengthInIn = 24,
                LifeExpectancyYears = 18,
                Id = Guid.Parse("cd490166-8fb4-43fc-aafc-ec3d953008e6")
            });

            modelBuilder.Entity<Color>().HasData(new Color { Name = "Gray", Id = Guid.Parse("d3b52dc5-db64-475a-9f51-1da5e8b14c98") });

            modelBuilder.Entity<Dessert>().HasData(new Dessert
            {
                Name = "Cheesecake",
                Calories = 1200,
                Description = "Creamy delicious cheese dessert",
                IsDry = false
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}
