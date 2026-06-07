using CinemaAPI.Data;
using CinemaAPI.Models;
using Microsoft.EntityFrameworkCore;
using static System.Collections.Specialized.BitVector32;
using static System.Net.WebRequestMethods;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<CinemaDbContext>(
    (opt) => opt.UseInMemoryDatabase("CinemaDb"));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<CinemaDbContext>();

    if (!db.Movies.Any())
    {
        db.Movies.AddRange(
        new Movie { Id = 1, Title = "Inception", Genre = "Sci-Fi", DurationMin = 148 },
        new Movie { Id = 2, Title = "The Shawshank Redemption", Genre = "Drama", DurationMin = 142 },
new Movie { Id = 3, Title = "The Godfather", Genre = "Crime", DurationMin = 175 },
new Movie { Id = 4, Title = "Spirited Away", Genre = "Animation", DurationMin = 125 },
new Movie { Id = 5, Title = "Parasite", Genre = "Thriller", DurationMin = 132 },
new Movie { Id = 6, Title = "The Dark Knight", Genre = "Action", DurationMin = 152 },
new Movie { Id = 7, Title = "La La Land", Genre = "Musical", DurationMin = 128 },
new Movie { Id = 8, Title = "Amélie", Genre = "Romantic Comedy", DurationMin = 122 },
new Movie { Id = 9, Title = "Interstellar", Genre = "Sci-Fi", DurationMin = 169 },
new Movie { Id = 10, Title = "City of God", Genre = "Crime", DurationMin = 130 }
);

        db.SaveChanges();
    }
}
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<CinemaDbContext>();

    if (!db.Sessions.Any())
    {
        db.Sessions.AddRange(
        new Session { Id = 1, MovieID = 1, StartTime = new DateTime(2026, 6, 7, 14, 0, 0), Hall = "A" },
        new Session { Id = 2, MovieID = 1, StartTime = new DateTime(2026, 6, 7, 19, 30, 0), Hall = "B" },
        new Session { Id = 3, MovieID = 2, StartTime = new DateTime(2026, 6, 8, 16, 0, 0), Hall = "A" },
        new Session { Id = 4, MovieID = 3, StartTime = new DateTime(2026, 6, 8, 20, 0, 0), Hall = "C" },
        new Session { Id = 5, MovieID = 4, StartTime = new DateTime(2026, 6, 9, 12, 30, 0), Hall = "D" },
        new Session { Id = 7, MovieID = 6, StartTime = new DateTime(2026, 6, 10, 21, 0, 0), Hall = "A" },
        new Session { Id = 8, MovieID = 7, StartTime = new DateTime(2026, 6, 10, 17, 30, 0), Hall = "C" },
        new Session { Id = 9, MovieID = 8, StartTime = new DateTime(2026, 6, 11, 15, 0, 0), Hall = "D" },
        new Session { Id = 10, MovieID = 9, StartTime = new DateTime(2026, 6, 11, 20, 30, 0), Hall = "B" }
        );

        db.SaveChanges();
    }
}
app.MapControllers();
app.UseHttpsRedirection();
app.UseAuthorization();
app.Run();