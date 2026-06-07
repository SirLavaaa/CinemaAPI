using System.ComponentModel.DataAnnotations;

namespace CinemaAPI.DTO
{
    public class CreateTicketDto
    {
        public int SessionId { get; set; }
        [Required]
        public string CustomerName { get; set; }

        [Range(0, 100)]
        public int SeatNumber { get; set; }
    }
}
