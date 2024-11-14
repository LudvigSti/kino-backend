using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBackendAPI.Models
{
    [Table("Genre")]
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }
        public string Name { get; set; }

        public ICollection<MovieWithGenre> MovieWithGenres { get; set; }

        public Genre(int genreId, string name)
        {
            GenreId = genreId;
            Name = name;
        }
    }
}