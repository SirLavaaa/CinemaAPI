namespace CinemaAPI.Models
{
    public class Session
    {
        public int Id { get; set; }
        public int MovieID { get; set; }
        public DateTime StartTime { get; set; }
        public string Hall { get; set; }
    }
}
