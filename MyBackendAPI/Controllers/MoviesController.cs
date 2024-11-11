using Microsoft.AspNetCore.Mvc;
using MyBackendAPI.Models;
using System.Collections.Generic;
using System.Linq;

[ApiController]
[Route("api/[controller]")]
public class MoviesController : ControllerBase
{
    // Simulated in-memory data store
    private static List<Movie> movies = new List<Movie>
    {
        new Movie(1, "The Big Lebowski", "Comedy", 1998, "Ethan Coen, Joel Coen"),
        new Movie(2, "Seven Samurai", "Action", 1954, "Akira Kurosawa")
    };

    // GET: api/movies
    [HttpGet]
    public ActionResult<IEnumerable<Movie>> GetAllMovies()
    {
        return Ok(movies);
    }

    // GET api/movies/{id}
    [HttpGet("{id}")]
    public ActionResult<Movie> GetMovieById(int id)
    {
        var movie = movies.FirstOrDefault(m => m.Id == id);
        if (movie == null) return NotFound();
        return Ok(movie);
    }
}
