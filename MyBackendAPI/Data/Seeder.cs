using MyBackendAPI.Models;

namespace MyBackendAPI.Data
{
    public class Seeder
    {
        private List<Movie> _movies = new List<Movie>();

        public Seeder()
        {
            //Movies
            Movie movie1 = new Movie(1, "Scary Movie", 10, 16, 100, DateTime.UtcNow, "Bent Bernoft", "testimage");
            Movie movie2 = new Movie(2, "Star Wars", 10, 16, 100, DateTime.UtcNow, "Billy Bill", "testimage");
            Movie movie3 = new Movie(3, "Pew Pew Pew", 10, 16, 100, DateTime.UtcNow, "Anders Andersen", "testimage");

            _movies.Add(movie1);
            _movies.Add(movie2);
            _movies.Add(movie3);

            Console.WriteLine(MovieList);
        }

        public List<Movie> MovieList { get { return _movies; } }
    }
}
