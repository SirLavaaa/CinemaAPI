using CinemaAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAPI.Controller
{
    [ApiController]
    [Route("/api/session")]
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
