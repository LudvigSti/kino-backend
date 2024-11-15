﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyBackendAPI.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MyBackendAPI.Migrations
{
    [DbContext(typeof(CinemaContext))]
    partial class CinemaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MyBackendAPI.Models.CinemaHall", b =>
                {
                    b.Property<int>("HallId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("HallId"));

                    b.Property<int>("Capacity")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("HallId");

                    b.ToTable("CinemaHall");
                });

            modelBuilder.Entity("MyBackendAPI.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("GenreId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("GenreId");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("MyBackendAPI.Models.LikedMovie", b =>
                {
                    b.Property<int>("ProfileId")
                        .HasColumnType("integer");

                    b.Property<int>("MovieId")
                        .HasColumnType("integer");

                    b.HasKey("ProfileId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("LikedMovie");
                });

            modelBuilder.Entity("MyBackendAPI.Models.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MovieId"));

                    b.Property<int>("AgeRating")
                        .HasColumnType("integer");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Duration")
                        .HasColumnType("integer");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ReleaseYear")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("MovieId");

                    b.ToTable("Movie");

                    b.HasData(
                        new
                        {
                            MovieId = 1,
                            AgeRating = 16,
                            Director = "Bent Bernoft",
                            Duration = 100,
                            Image = "testimage",
                            Rating = 10,
                            ReleaseYear = new DateTime(2024, 11, 14, 12, 29, 6, 0, DateTimeKind.Utc).AddTicks(9356),
                            Title = "Scary Movie"
                        },
                        new
                        {
                            MovieId = 2,
                            AgeRating = 16,
                            Director = "Billy Bill",
                            Duration = 100,
                            Image = "testimage",
                            Rating = 10,
                            ReleaseYear = new DateTime(2024, 11, 14, 12, 29, 6, 0, DateTimeKind.Utc).AddTicks(9378),
                            Title = "Star Wars"
                        },
                        new
                        {
                            MovieId = 3,
                            AgeRating = 16,
                            Director = "Anders Andersen",
                            Duration = 100,
                            Image = "testimage",
                            Rating = 10,
                            ReleaseYear = new DateTime(2024, 11, 14, 12, 29, 6, 0, DateTimeKind.Utc).AddTicks(9381),
                            Title = "Pew Pew Pew"
                        });
                });

            modelBuilder.Entity("MyBackendAPI.Models.MovieWithGenre", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("integer");

                    b.Property<int>("GenreId")
                        .HasColumnType("integer");

                    b.HasKey("MovieId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("MovieWithGenre");
                });

            modelBuilder.Entity("MyBackendAPI.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OrderId"));

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Total")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("MyBackendAPI.Models.Profile", b =>
                {
                    b.Property<int>("ProfileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProfileId"));

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Points")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("ProfileId");

                    b.HasIndex("UserId");

                    b.ToTable("Profile");
                });

            modelBuilder.Entity("MyBackendAPI.Models.Screening", b =>
                {
                    b.Property<int>("ScreeningId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ScreeningId"));

                    b.Property<int>("HallId")
                        .HasColumnType("integer");

                    b.Property<int>("MovieId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ScreeningTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ScreeningId");

                    b.HasIndex("HallId");

                    b.HasIndex("MovieId");

                    b.ToTable("Screening");
                });

            modelBuilder.Entity("MyBackendAPI.Models.Ticket", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TicketId"));

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<int>("ScreeningId")
                        .HasColumnType("integer");

                    b.HasKey("TicketId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ScreeningId");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("MyBackendAPI.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Email = "example@gmail.com",
                            Password = "Puppy123"
                        },
                        new
                        {
                            UserId = 2,
                            Email = "email@email.com",
                            Password = "ILoveMom9999"
                        });
                });

            modelBuilder.Entity("MyBackendAPI.Models.WatchedMovie", b =>
                {
                    b.Property<int>("ProfileId")
                        .HasColumnType("integer");

                    b.Property<int>("MovieId")
                        .HasColumnType("integer");

                    b.HasKey("ProfileId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("WatchedMovie");
                });

            modelBuilder.Entity("MyBackendAPI.Models.LikedMovie", b =>
                {
                    b.HasOne("MyBackendAPI.Models.Movie", "Movie")
                        .WithMany("LikedMovie")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBackendAPI.Models.Profile", "Profile")
                        .WithMany("LikedMovie")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("MyBackendAPI.Models.MovieWithGenre", b =>
                {
                    b.HasOne("MyBackendAPI.Models.Genre", "Genre")
                        .WithMany("MovieWithGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBackendAPI.Models.Movie", "Movie")
                        .WithMany("MovieWithGenres")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MyBackendAPI.Models.Order", b =>
                {
                    b.HasOne("MyBackendAPI.Models.User", "User")
                        .WithMany("Order")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyBackendAPI.Models.Profile", b =>
                {
                    b.HasOne("MyBackendAPI.Models.User", "User")
                        .WithMany("Profile")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyBackendAPI.Models.Screening", b =>
                {
                    b.HasOne("MyBackendAPI.Models.CinemaHall", "CinemaHall")
                        .WithMany("Screening")
                        .HasForeignKey("HallId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBackendAPI.Models.Movie", "Movie")
                        .WithMany("Screenings")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CinemaHall");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MyBackendAPI.Models.Ticket", b =>
                {
                    b.HasOne("MyBackendAPI.Models.Order", "Order")
                        .WithMany("Ticket")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBackendAPI.Models.Screening", "Screening")
                        .WithMany()
                        .HasForeignKey("ScreeningId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Screening");
                });

            modelBuilder.Entity("MyBackendAPI.Models.WatchedMovie", b =>
                {
                    b.HasOne("MyBackendAPI.Models.Movie", "Movie")
                        .WithMany("WatchedMovie")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBackendAPI.Models.Profile", "Profile")
                        .WithMany("WatchedMovie")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("MyBackendAPI.Models.CinemaHall", b =>
                {
                    b.Navigation("Screening");
                });

            modelBuilder.Entity("MyBackendAPI.Models.Genre", b =>
                {
                    b.Navigation("MovieWithGenres");
                });

            modelBuilder.Entity("MyBackendAPI.Models.Movie", b =>
                {
                    b.Navigation("LikedMovie");

                    b.Navigation("MovieWithGenres");

                    b.Navigation("Screenings");

                    b.Navigation("WatchedMovie");
                });

            modelBuilder.Entity("MyBackendAPI.Models.Order", b =>
                {
                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("MyBackendAPI.Models.Profile", b =>
                {
                    b.Navigation("LikedMovie");

                    b.Navigation("WatchedMovie");
                });

            modelBuilder.Entity("MyBackendAPI.Models.User", b =>
                {
                    b.Navigation("Order");

                    b.Navigation("Profile");
                });
#pragma warning restore 612, 618
        }
    }
}
