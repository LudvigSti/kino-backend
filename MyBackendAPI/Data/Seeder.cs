using MyBackendAPI.Models;

namespace MyBackendAPI.Data
{
    public class Seeder
    {
        private List<Movie> _movies = new List<Movie>();
        private List<User> _users = new List<User>();
        private List<Profile> _profiles = new List<Profile>();

        public Seeder()
        {
            //Movies
            Movie movie1 = new Movie(1, "Scary Movie", 10, 16, 100, DateTime.UtcNow, "Bent Bernoft", "https://www.imdb.com/title/tt0175142/mediaviewer/rm3954579456/?ref_=tt_ov_i");
            Movie movie2 = new Movie(2, "Star Wars", 10, 16, 100, DateTime.UtcNow, "Billy Bill", "testimage");
            Movie movie3 = new Movie(3, "Pew Pew Pew", 10, 16, 100, DateTime.UtcNow, "Anders Andersen", "testimage");

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

        }

        public List<Movie> MovieList { get { return _movies; } }
        public List<User> UserList { get { return _users;  } }
        public List<Profile> ProfileList { get { return _profiles;  } }
    }
}
