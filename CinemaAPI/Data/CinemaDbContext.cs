using CinemaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaAPI.Data
{
    public class CinemaDbContext: DbContext
    {
        public CinemaDbContext(DbContextOptions<CinemaDbContext> options) : base(options) { }
        public DbSet<Movie> Movies => Set<Movie>();
        public DbSet<Session> Sessions => Set<Session>();
        public DbSet<Ticket> Tickets => Set<Ticket>();

    }
}
