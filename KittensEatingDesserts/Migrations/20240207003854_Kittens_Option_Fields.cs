using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KittensEatingDesserts.Migrations
{
    public partial class Kittens_Option_Fields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kittens_Breeds_BreedId",
                table: "Kittens");

            migrationBuilder.DropForeignKey(
                name: "FK_Kittens_Desserts_FavoriteDessertId",
                table: "Kittens");

            migrationBuilder.AlterColumn<int>(
                name: "LivesRemaining",
                table: "Kittens",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<Guid>(
                name: "FavoriteDessertId",
                table: "Kittens",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<Guid>(
                name: "BreedId",
                table: "Kittens",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_Kittens_Breeds_BreedId",
                table: "Kittens",
                column: "BreedId",
                principalTable: "Breeds",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Kittens_Desserts_FavoriteDessertId",
                table: "Kittens",
                column: "FavoriteDessertId",
                principalTable: "Desserts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kittens_Breeds_BreedId",
                table: "Kittens");

            migrationBuilder.DropForeignKey(
                name: "FK_Kittens_Desserts_FavoriteDessertId",
                table: "Kittens");

            migrationBuilder.AlterColumn<int>(
                name: "LivesRemaining",
                table: "Kittens",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "FavoriteDessertId",
                table: "Kittens",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "BreedId",
                table: "Kittens",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Kittens_Breeds_BreedId",
                table: "Kittens",
                column: "BreedId",
                principalTable: "Breeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Kittens_Desserts_FavoriteDessertId",
                table: "Kittens",
                column: "FavoriteDessertId",
                principalTable: "Desserts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
