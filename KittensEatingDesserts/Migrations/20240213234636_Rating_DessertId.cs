using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KittensEatingDesserts.Migrations
{
    public partial class Rating_DessertId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DessertRating");

            migrationBuilder.DeleteData(
                table: "Desserts",
                keyColumn: "Id",
                keyValue: new Guid("046e4424-82d3-4fd6-969b-4b5fd0e6a47a"));

            migrationBuilder.AddColumn<Guid>(
                name: "DessertId",
                table: "Ratings",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Desserts",
                columns: new[] { "Id", "Calories", "Description", "IsDry", "IsWarm", "Name" },
                values: new object[] { new Guid("ec9c8aa4-15e3-42dd-ac91-3d318cda4f45"), 1200, "Creamy delicious cheese dessert", false, false, "Cheesecake" });

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_DessertId",
                table: "Ratings",
                column: "DessertId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Desserts_DessertId",
                table: "Ratings",
                column: "DessertId",
                principalTable: "Desserts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Desserts_DessertId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_DessertId",
                table: "Ratings");

            migrationBuilder.DeleteData(
                table: "Desserts",
                keyColumn: "Id",
                keyValue: new Guid("ec9c8aa4-15e3-42dd-ac91-3d318cda4f45"));

            migrationBuilder.DropColumn(
                name: "DessertId",
                table: "Ratings");

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

            migrationBuilder.InsertData(
                table: "Desserts",
                columns: new[] { "Id", "Calories", "Description", "IsDry", "IsWarm", "Name" },
                values: new object[] { new Guid("046e4424-82d3-4fd6-969b-4b5fd0e6a47a"), 1200, "Creamy delicious cheese dessert", false, false, "Cheesecake" });

            migrationBuilder.CreateIndex(
                name: "IX_DessertRating_RatingsId",
                table: "DessertRating",
                column: "RatingsId");
        }
    }
}
