using CinemaAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAPI.Controller
{
    [ApiController]
    [Route("/api/movies")]
    public class MoviesController : ControllerBase
    {
            private readonly CinemaDbContext _db;

            public MoviesController(CinemaDbContext db)
            {
                _db = db;
            }

            [HttpGet]
            public IActionResult GetMovies()
            {
                return Ok(_db.Movies.ToList());
            }
     }
}

