using CinemaAPI.Data;
using CinemaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using CinemaAPI.DTO;

namespace CinemaAPI.Controller
{
    [ApiController]
    [Route("api/tickets")]
    public class TicketsController : ControllerBase
    {
        private readonly CinemaDbContext _db;

        public TicketsController(CinemaDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetTicket()
        {
            return Ok(_db.Tickets.ToList());
        }

        [HttpPost]
        public IActionResult BuyTicket(CreateTicketDto dto)
        {
            var sessionExists = _db.Sessions.Any(session => session.Id == dto.SessionId);

            if (!sessionExists)
            {
                return NotFound("Session not found");
            }

            var seatAlredySold = _db.Tickets.Any(ticket => ticket.SessionId == dto.SessionId && ticket.SeatNumber == dto.SeatNumber);

            if (seatAlredySold)
            {
                return BadRequest("This seat is already sold");
            }

            var ticket = new Ticket
            {
                SessionId = dto.SessionId,
                CustomerName = dto.CustomerName,
                SeatNumber = dto.SeatNumber,
            };

            _db.Tickets.Add(ticket);
            _db.SaveChanges();

            return Created("", ticket);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTicket(int id)
        {
            if (_db.Tickets.Find(id) is Ticket ticket)
            {
                _db.Tickets.Remove(ticket);
                _db.SaveChanges();
                return NoContent();
            }
            return NotFound("Ticket not found");
        }
    }
}
