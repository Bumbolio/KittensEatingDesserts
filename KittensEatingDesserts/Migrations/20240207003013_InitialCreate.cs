using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KittensEatingDesserts.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Breeds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    HairLengthIn = table.Column<int>(type: "INTEGER", nullable: false),
                    IsPurrBread = table.Column<bool>(type: "INTEGER", nullable: false),
                    LengthInIn = table.Column<int>(type: "INTEGER", nullable: false),
                    LifeExpectancyYears = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breeds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Desserts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Calories = table.Column<int>(type: "INTEGER", nullable: false),
                    IsWarm = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDry = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desserts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AssignedRating = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kittens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    LivesRemaining = table.Column<int>(type: "INTEGER", nullable: false),
                    BreedId = table.Column<Guid>(type: "TEXT", nullable: false),
                    FavoriteDessertId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kittens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kittens_Breeds_BreedId",
                        column: x => x.BreedId,
                        principalTable: "Breeds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kittens_Desserts_FavoriteDessertId",
                        column: x => x.FavoriteDessertId,
                        principalTable: "Desserts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DessertRating",
                columns: table => new
                {
                    DessertsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RatingsId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DessertRating", x => new { x.DessertsId, x.RatingsId });
                    table.ForeignKey(
                        name: "FK_DessertRating_Desserts_DessertsId",
                        column: x => x.DessertsId,
                        principalTable: "Desserts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DessertRating_Ratings_RatingsId",
                        column: x => x.RatingsId,
                        principalTable: "Ratings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    KittenId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Colors_Kittens_KittenId",
                        column: x => x.KittenId,
                        principalTable: "Kittens",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colors_KittenId",
                table: "Colors",
                column: "KittenId");

            migrationBuilder.CreateIndex(
                name: "IX_DessertRating_RatingsId",
                table: "DessertRating",
                column: "RatingsId");

            migrationBuilder.CreateIndex(
                name: "IX_Kittens_BreedId",
                table: "Kittens",
                column: "BreedId");

            migrationBuilder.CreateIndex(
                name: "IX_Kittens_FavoriteDessertId",
                table: "Kittens",
                column: "FavoriteDessertId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "DessertRating");

            migrationBuilder.DropTable(
                name: "Kittens");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Breeds");

            migrationBuilder.DropTable(
                name: "Desserts");
        }
    }
}
