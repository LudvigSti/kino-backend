using Microsoft.EntityFrameworkCore;
using MyBackendAPI.Models;
using System.Diagnostics;

namespace MyBackendAPI.Data
{
    public class CinemaContext : DbContext
    {
        private string _connectionString;

        public CinemaContext(DbContextOptions<CinemaContext> options) : base(options)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnectionString")!;
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
            optionsBuilder.LogTo(message => Debug.WriteLine(message)); //see the sql EF using in the console
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LikedMovies>()
                .HasKey(lm => new { lm.ProfileId, lm.MovieId });

            modelBuilder.Entity<MovieWithGenre>()
                .HasKey(mg => new { mg.MovieId, mg.GenreId });

            modelBuilder.Entity<WatchedMovies>()
                .HasKey(wm => new { wm.ProfileId, wm.MovieId });

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Movie> Movies { get; set; }
    }
}
