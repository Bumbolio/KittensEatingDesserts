using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KittensEatingDesserts.Migrations
{
    public partial class InitialSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Breeds",
                columns: new[] { "Id", "Description", "HairLengthIn", "IsPurrBread", "LengthInIn", "LifeExpectancyYears", "Name" },
                values: new object[] { new Guid("cd490166-8fb4-43fc-aafc-ec3d953008e6"), "Gianormous Cat with big paws.", 3, true, 24, 18, "Maine Coon" });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "KittenId", "Name" },
                values: new object[] { new Guid("d3b52dc5-db64-475a-9f51-1da5e8b14c98"), null, "Gray" });

            migrationBuilder.InsertData(
                table: "Desserts",
                columns: new[] { "Id", "Calories", "Description", "IsDry", "IsWarm", "Name" },
                values: new object[] { new Guid("046e4424-82d3-4fd6-969b-4b5fd0e6a47a"), 1200, "Creamy delicious cheese dessert", false, false, "Cheesecake" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: new Guid("cd490166-8fb4-43fc-aafc-ec3d953008e6"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("d3b52dc5-db64-475a-9f51-1da5e8b14c98"));

            migrationBuilder.DeleteData(
                table: "Desserts",
                keyColumn: "Id",
                keyValue: new Guid("046e4424-82d3-4fd6-969b-4b5fd0e6a47a"));
        }
    }
}
