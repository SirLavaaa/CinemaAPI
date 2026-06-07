using CinemaAPI.Data;
using CinemaAPI.DTO;
using CinemaAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAPI.Controller
{
    [ApiController]
    [Route("/api/sessions")]
    public class SessionController : ControllerBase
    {
        private readonly CinemaDbContext _db;

        public SessionController(CinemaDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetSession()
        {
            return Ok(_db.Sessions.ToList());
        }
    }
}
