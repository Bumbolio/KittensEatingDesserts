﻿// <auto-generated />
using System;
using KittensEatingDesserts.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KittensEatingDesserts.Migrations
{
    [DbContext(typeof(KittensEatingDessertsContext))]
    partial class KittensEatingDessertsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.26");

            modelBuilder.Entity("DessertRating", b =>
                {
                    b.Property<Guid>("DessertsId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RatingsId")
                        .HasColumnType("TEXT");

                    b.HasKey("DessertsId", "RatingsId");

                    b.HasIndex("RatingsId");

                    b.ToTable("DessertRating");
                });

            modelBuilder.Entity("KittensEatingDesserts.Models.Breed", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("HairLengthIn")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsPurrBread")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LengthInIn")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LifeExpectancyYears")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Breeds");

                    b.HasData(
                        new
                        {
                            Id = new Guid("cd490166-8fb4-43fc-aafc-ec3d953008e6"),
                            Description = "Gianormous Cat with big paws.",
                            HairLengthIn = 3,
                            IsPurrBread = true,
                            LengthInIn = 24,
                            LifeExpectancyYears = 18,
                            Name = "Maine Coon"
                        });
                });

            modelBuilder.Entity("KittensEatingDesserts.Models.Color", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("KittenId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("KittenId");

                    b.ToTable("Colors");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d3b52dc5-db64-475a-9f51-1da5e8b14c98"),
                            Name = "Gray"
                        });
                });

            modelBuilder.Entity("KittensEatingDesserts.Models.Dessert", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Calories")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDry")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsWarm")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Desserts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("046e4424-82d3-4fd6-969b-4b5fd0e6a47a"),
                            Calories = 1200,
                            Description = "Creamy delicious cheese dessert",
                            IsDry = false,
                            IsWarm = false,
                            Name = "Cheesecake"
                        });
                });

            modelBuilder.Entity("KittensEatingDesserts.Models.Kitten", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("BreedId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("FavoriteDessertId")
                        .HasColumnType("TEXT");

                    b.Property<int?>("LivesRemaining")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BreedId");

                    b.HasIndex("FavoriteDessertId");

                    b.ToTable("Kittens");
                });

            modelBuilder.Entity("KittensEatingDesserts.Models.Rating", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("AssignedRating")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("DessertRating", b =>
                {
                    b.HasOne("KittensEatingDesserts.Models.Dessert", null)
                        .WithMany()
                        .HasForeignKey("DessertsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KittensEatingDesserts.Models.Rating", null)
                        .WithMany()
                        .HasForeignKey("RatingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KittensEatingDesserts.Models.Color", b =>
                {
                    b.HasOne("KittensEatingDesserts.Models.Kitten", null)
                        .WithMany("Colors")
                        .HasForeignKey("KittenId");
                });

            modelBuilder.Entity("KittensEatingDesserts.Models.Kitten", b =>
                {
                    b.HasOne("KittensEatingDesserts.Models.Breed", "Breed")
                        .WithMany()
                        .HasForeignKey("BreedId");

                    b.HasOne("KittensEatingDesserts.Models.Dessert", "FavoriteDessert")
                        .WithMany()
                        .HasForeignKey("FavoriteDessertId");

                    b.Navigation("Breed");

                    b.Navigation("FavoriteDessert");
                });

            modelBuilder.Entity("KittensEatingDesserts.Models.Kitten", b =>
                {
                    b.Navigation("Colors");
                });
#pragma warning restore 612, 618
        }
    }
}
