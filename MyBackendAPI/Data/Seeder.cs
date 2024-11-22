using MyBackendAPI.Models;

namespace MyBackendAPI.Data
{
    public class Seeder
    {
        private List<Movie> _movies = new List<Movie>();
        private List<User> _users = new List<User>();
        private List<Profile> _profiles = new List<Profile>();
        private List<CinemaHall> _halls = new List<CinemaHall>();
        private List<Screening> _screenings = new List<Screening>();

        public Seeder()
        {
            //Movies
            Movie movie1 = new Movie(1, "Scary Movie", 10, 16, 100, new DateOnly(2021, 1, 1), "Bent Bernoft", new List<string> { 
                "https://www.imdb.com/title/tt0175142/mediaviewer/rm3954579456/?ref_=tt_ov_i",
                "https://c8.alamy.com/comp/2JHCP0R/scary-movie-film-poster-scary-movie-2000-2JHCP0R.jpg" 
            }, "https://youtu.be/SzpGYrrcJZw");
            Movie movie2 = new Movie(2, "Star Wars", 10, 16, 100, new DateOnly(1996, 1, 1), "Billy Bill", new List<string> { 
                "https://i.ebayimg.com/00/s/MTYwMFgxMDY2/z/oZ0AAOSwSj1jJjKs/$_57.JPG?set_id=880000500F",
                "https://images6.alphacoders.com/111/1115518.jpg"
            }, "https://youtu.be/5UnjrG_N8hU");
            Movie movie3 = new Movie(3, "Inception", 10, 16, 122, new DateOnly(2016, 1, 1), "Anders Andersen", new List<string> {
                "https://i.ebayimg.com/images/g/hX8AAOSwk5FUwoPc/s-l1200.jpg",
                "https://images7.alphacoders.com/518/518783.jpg"
            }, "https://youtu.be/LifqWf0BAOA");

            _movies.Add(movie1);
            _movies.Add(movie2);
            _movies.Add(movie3);

            //Users
            User user1 = new User("example@gmail.com", "Puppy123");
            user1.UserId = 1;
            User user2 = new User("email@email.com", "ILoveMom9999");
            user2.UserId = 2;

            _users.Add(user1);
            _users.Add(user2);

            //Profiles
            Profile profile1 = new Profile("John", "Doe", 1, new DateOnly(1990, 1, 1), "icon", 0);
            profile1.ProfileId = 1;
            Profile profile2 = new Profile("Jane", "Doe", 2, new DateOnly(1990, 1, 1), "icon", 0);
            profile2.ProfileId = 2;

            _profiles.Add(profile1);
            _profiles.Add(profile2);

            //CinemaHalls
            CinemaHall hall1 = new CinemaHall(1, "Oslo big", 200);
            CinemaHall hall2 = new CinemaHall(2, "Oslo small", 50);
            CinemaHall hall3 = new CinemaHall(3, "Bergen big", 10);
            CinemaHall hall4 = new CinemaHall(4, "Bergen small", 2);

            _halls.Add(hall1);
            _halls.Add(hall2);
            _halls.Add(hall3);
            _halls.Add(hall4);

            //Screenings
            Screening screening1 = new Screening(DateTime.UtcNow, 2, 1, "3D");
            screening1.ScreeningId = 1;
            Screening screening2 = new Screening(DateTime.UtcNow, 1, 1, "2D");
            screening2.ScreeningId = 2;
            Screening screening3 = new Screening(DateTime.UtcNow, 3, 1, "Norsk tale");
            screening3.ScreeningId = 3;
            Screening screening4 = new Screening(DateTime.UtcNow, 2, 2, "Original tale");
            screening4.ScreeningId = 4;
            Screening screening5 = new Screening(DateTime.UtcNow, 2, 3, "3D");
            screening5.ScreeningId = 5;
            Screening screening6 = new Screening(DateTime.UtcNow, 4, 2, "3D");
            screening6.ScreeningId = 6;
            Screening screening7 = new Screening(DateTime.UtcNow, 3, 2, "3D");
            screening7.ScreeningId = 7;

            _screenings.Add(screening1);
            _screenings.Add(screening2);
            _screenings.Add(screening3);
            _screenings.Add(screening4);
            _screenings.Add(screening5);
            _screenings.Add(screening6);
            _screenings.Add(screening7);
        }

        public List<Movie> MovieList { get { return _movies; } }
        public List<User> UserList { get { return _users;  } }
        public List<Profile> ProfileList { get { return _profiles;  } }
        public List<CinemaHall> CinemaHallList { get { return _halls;  } }
        public List<Screening> ScreeningList { get { return _screenings; } }
    }
}
