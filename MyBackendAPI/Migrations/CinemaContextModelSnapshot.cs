﻿// <auto-generated />
using System;
using System.Collections.Generic;
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

                    b.HasData(
                        new
                        {
                            HallId = 1,
                            Capacity = 200,
                            Name = "Oslo big"
                        },
                        new
                        {
                            HallId = 2,
                            Capacity = 50,
                            Name = "Oslo small"
                        },
                        new
                        {
                            HallId = 3,
                            Capacity = 10,
                            Name = "Bergen big"
                        },
                        new
                        {
                            HallId = 4,
                            Capacity = 2,
                            Name = "Bergen small"
                        });
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

                    b.Property<List<string>>("Images")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<DateOnly>("ReleaseDate")
                        .HasColumnType("date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Trailer")
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
                            Images = new List<string> { "https://www.imdb.com/title/tt0175142/mediaviewer/rm3954579456/?ref_=tt_ov_i", "https://c8.alamy.com/comp/2JHCP0R/scary-movie-film-poster-scary-movie-2000-2JHCP0R.jpg" },
                            Rating = 10,
                            ReleaseDate = new DateOnly(2021, 1, 1),
                            Title = "Scary Movie",
                            Trailer = "https://youtu.be/SzpGYrrcJZw"
                        },
                        new
                        {
                            MovieId = 2,
                            AgeRating = 16,
                            Director = "Billy Bill",
                            Duration = 100,
                            Images = new List<string> { "https://i.ebayimg.com/00/s/MTYwMFgxMDY2/z/oZ0AAOSwSj1jJjKs/$_57.JPG?set_id=880000500F", "https://images6.alphacoders.com/111/1115518.jpg" },
                            Rating = 10,
                            ReleaseDate = new DateOnly(1996, 1, 1),
                            Title = "Star Wars",
                            Trailer = "https://youtu.be/5UnjrG_N8hU"
                        },
                        new
                        {
                            MovieId = 3,
                            AgeRating = 16,
                            Director = "Anders Andersen",
                            Duration = 122,
                            Images = new List<string> { "https://i.ebayimg.com/images/g/hX8AAOSwk5FUwoPc/s-l1200.jpg", "https://images7.alphacoders.com/518/518783.jpg" },
                            Rating = 10,
                            ReleaseDate = new DateOnly(2016, 1, 1),
                            Title = "Inception",
                            Trailer = "https://youtu.be/LifqWf0BAOA"
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

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Profile");

                    b.HasData(
                        new
                        {
                            ProfileId = 1,
                            DateOfBirth = new DateOnly(1990, 1, 1),
                            FirstName = "John",
                            Icon = "icon",
                            LastName = "Doe",
                            Points = 0,
                            UserId = 1
                        },
                        new
                        {
                            ProfileId = 2,
                            DateOfBirth = new DateOnly(1990, 1, 1),
                            FirstName = "Jane",
                            Icon = "icon",
                            LastName = "Doe",
                            Points = 0,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("MyBackendAPI.Models.Screening", b =>
                {
                    b.Property<int>("ScreeningId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ScreeningId"));

                    b.Property<string>("About")
                        .HasColumnType("text");

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

                    b.HasData(
                        new
                        {
                            ScreeningId = 1,
                            About = "3D",
                            HallId = 2,
                            MovieId = 1,
                            ScreeningTime = new DateTime(2024, 11, 22, 9, 27, 46, 198, DateTimeKind.Utc).AddTicks(2458)
                        },
                        new
                        {
                            ScreeningId = 2,
                            About = "2D",
                            HallId = 1,
                            MovieId = 1,
                            ScreeningTime = new DateTime(2024, 11, 22, 9, 27, 46, 198, DateTimeKind.Utc).AddTicks(2463)
                        },
                        new
                        {
                            ScreeningId = 3,
                            About = "Norsk tale",
                            HallId = 3,
                            MovieId = 1,
                            ScreeningTime = new DateTime(2024, 11, 22, 9, 27, 46, 198, DateTimeKind.Utc).AddTicks(2464)
                        },
                        new
                        {
                            ScreeningId = 4,
                            About = "Original tale",
                            HallId = 2,
                            MovieId = 2,
                            ScreeningTime = new DateTime(2024, 11, 22, 9, 27, 46, 198, DateTimeKind.Utc).AddTicks(2465)
                        },
                        new
                        {
                            ScreeningId = 5,
                            About = "3D",
                            HallId = 2,
                            MovieId = 3,
                            ScreeningTime = new DateTime(2024, 11, 22, 9, 27, 46, 198, DateTimeKind.Utc).AddTicks(2465)
                        },
                        new
                        {
                            ScreeningId = 6,
                            About = "3D",
                            HallId = 4,
                            MovieId = 2,
                            ScreeningTime = new DateTime(2024, 11, 22, 9, 27, 46, 198, DateTimeKind.Utc).AddTicks(2466)
                        },
                        new
                        {
                            ScreeningId = 7,
                            About = "3D",
                            HallId = 3,
                            MovieId = 2,
                            ScreeningTime = new DateTime(2024, 11, 22, 9, 27, 46, 198, DateTimeKind.Utc).AddTicks(2467)
                        });
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
                            Password = "$2a$11$F6ioen1Bi.nQzemG.1hotutn95aT8S.g7syl8VyDTmx9uF9I4U7mq"
                        },
                        new
                        {
                            UserId = 2,
                            Email = "email@email.com",
                            Password = "$2a$11$L1WljVnvDDzhNo8pQSlIveAAPnElws0YkXauFC4wooTcTuRiKzeoe"
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
                        .WithOne("Profile")
                        .HasForeignKey("MyBackendAPI.Models.Profile", "UserId")
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

                    b.Navigation("Profile")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
