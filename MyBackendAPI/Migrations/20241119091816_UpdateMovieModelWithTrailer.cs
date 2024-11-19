using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyBackendAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMovieModelWithTrailer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CinemaHall",
                columns: table => new
                {
                    HallId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Capacity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaHall", x => x.HallId);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    AgeRating = table.Column<int>(type: "integer", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    ReleaseYear = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Director = table.Column<string>(type: "text", nullable: false),
                    Images = table.Column<List<string>>(type: "text[]", nullable: false),
                    Trailer = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.MovieId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "MovieWithGenre",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "integer", nullable: false),
                    GenreId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieWithGenre", x => new { x.MovieId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_MovieWithGenre_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieWithGenre_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Screening",
                columns: table => new
                {
                    ScreeningId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ScreeningTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    HallId = table.Column<int>(type: "integer", nullable: false),
                    MovieId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Screening", x => x.ScreeningId);
                    table.ForeignKey(
                        name: "FK_Screening_CinemaHall_HallId",
                        column: x => x.HallId,
                        principalTable: "CinemaHall",
                        principalColumn: "HallId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Screening_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Total = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    ProfileId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    Icon = table.Column<string>(type: "text", nullable: false),
                    Points = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.ProfileId);
                    table.ForeignKey(
                        name: "FK_Profile_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    ScreeningId = table.Column<int>(type: "integer", nullable: false),
                    OrderId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Ticket_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_Screening_ScreeningId",
                        column: x => x.ScreeningId,
                        principalTable: "Screening",
                        principalColumn: "ScreeningId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LikedMovie",
                columns: table => new
                {
                    ProfileId = table.Column<int>(type: "integer", nullable: false),
                    MovieId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikedMovie", x => new { x.ProfileId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_LikedMovie_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LikedMovie_Profile_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profile",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WatchedMovie",
                columns: table => new
                {
                    ProfileId = table.Column<int>(type: "integer", nullable: false),
                    MovieId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchedMovie", x => new { x.ProfileId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_WatchedMovie_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WatchedMovie_Profile_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profile",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "MovieId", "AgeRating", "Director", "Duration", "Images", "Rating", "ReleaseYear", "Title", "Trailer" },
                values: new object[,]
                {
                    { 1, 16, "Bent Bernoft", 100, new List<string> { "https://www.imdb.com/title/tt0175142/mediaviewer/rm3954579456/?ref_=tt_ov_i", "https://c8.alamy.com/comp/2JHCP0R/scary-movie-film-poster-scary-movie-2000-2JHCP0R.jpg" }, 10, new DateTime(2024, 11, 19, 9, 18, 14, 932, DateTimeKind.Utc).AddTicks(2738), "Scary Movie", "https://youtu.be/SzpGYrrcJZw" },
                    { 2, 16, "Billy Bill", 100, new List<string> { "https://i.ebayimg.com/00/s/MTYwMFgxMDY2/z/oZ0AAOSwSj1jJjKs/$_57.JPG?set_id=880000500F", "https://images6.alphacoders.com/111/1115518.jpg" }, 10, new DateTime(2024, 11, 19, 9, 18, 14, 932, DateTimeKind.Utc).AddTicks(2778), "Star Wars", "https://youtu.be/5UnjrG_N8hU" },
                    { 3, 16, "Anders Andersen", 100, new List<string> { "https://i.ebayimg.com/images/g/hX8AAOSwk5FUwoPc/s-l1200.jpg", "https://images7.alphacoders.com/518/518783.jpg" }, 10, new DateTime(2024, 11, 19, 9, 18, 14, 932, DateTimeKind.Utc).AddTicks(2785), "Inception", "https://youtu.be/LifqWf0BAOA" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Email", "Password" },
                values: new object[,]
                {
                    { 1, "example@gmail.com", "Puppy123" },
                    { 2, "email@email.com", "ILoveMom9999" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LikedMovie_MovieId",
                table: "LikedMovie",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieWithGenre_GenreId",
                table: "MovieWithGenre",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                table: "Order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_UserId",
                table: "Profile",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Screening_HallId",
                table: "Screening",
                column: "HallId");

            migrationBuilder.CreateIndex(
                name: "IX_Screening_MovieId",
                table: "Screening",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_OrderId",
                table: "Ticket",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_ScreeningId",
                table: "Ticket",
                column: "ScreeningId");

            migrationBuilder.CreateIndex(
                name: "IX_WatchedMovie_MovieId",
                table: "WatchedMovie",
                column: "MovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LikedMovie");

            migrationBuilder.DropTable(
                name: "MovieWithGenre");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "WatchedMovie");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Screening");

            migrationBuilder.DropTable(
                name: "Profile");

            migrationBuilder.DropTable(
                name: "CinemaHall");

            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
