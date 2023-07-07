using MovieApp.Data;
using MovieApp.Models;
using MovieApp.Models.ViewModels;
using MovieApp.Services.Base;
using Microsoft.EntityFrameworkCore;

namespace MovieApp.Services.Movies;

public class MoviesService : EntityBaseService<Movie>, IMoviesService
{
    private readonly AppDbContext _context;
    public MoviesService(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task AddNewMovieAsync(NewMovieViewModel data)
    {
        var newMovie = new Movie()
        {
            Name = data.Name,
            Description = data.Description,
            ImageURL = data.ImageURL,
            CinemaId = data.CinemaId,
            StartDate = data.StartDate,
            EndDate = data.EndDate,
            MovieCategory = data.MovieCategory,
            ProducerId = data.ProducerId
        };
        await _context.Movies.AddAsync(newMovie);
        await _context.SaveChangesAsync();

        foreach (var actorId in data.ActorIds)
        {
            var newActorMovie = new Actor_Movie()
            {
                MovieId = newMovie.Id,
                ActorId = actorId
            };
            await _context.Actors_Movies.AddAsync(newActorMovie);
        }
        await _context.SaveChangesAsync();
    }

    public async Task<Movie> GetMovieByIdAsync(int id)
    {
        var movieDetails = await _context.Movies
            .Include(c => c.Cinema)
            .Include(p => p.Producer)
            .Include(am => am.Actors_Movies).ThenInclude(a => a.Actor)
            .FirstOrDefaultAsync(n => n.Id == id);
            
        return movieDetails;
    }

    public async Task<NewMovieDropDownViewModel> GetNewMovieDropdownsValues()
    {
        var response = new NewMovieDropDownViewModel()
        {
            Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync(),
            Cinemas = await _context.Cinemas.OrderBy(n => n.Name).ToListAsync(),
            Producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync()
        };

        return response;
    }

    public async Task UpdateMovieAsync(NewMovieViewModel data)
    {
        var dbMovie = await _context.Movies.FirstOrDefaultAsync(n => n.Id == data.Id);

        if (dbMovie != null)
        {
            dbMovie.Name = data.Name;
            dbMovie.Description = data.Description;
            dbMovie.ImageURL = data.ImageURL;
            dbMovie.CinemaId = data.CinemaId;
            dbMovie.StartDate = data.StartDate;
            dbMovie.EndDate = data.EndDate;
            dbMovie.MovieCategory = data.MovieCategory;
            dbMovie.ProducerId = data.ProducerId;
            await _context.SaveChangesAsync();
        }

        //Remove existing actors
        var existingActorsDb = _context.Actors_Movies.Where(n => n.MovieId == data.Id).ToList();
        _context.Actors_Movies.RemoveRange(existingActorsDb);
        await _context.SaveChangesAsync();

        //Add Movie Actors
        foreach (var actorId in data.ActorIds)
        {
            var newActorMovie = new Actor_Movie()
            {
                MovieId = data.Id,
                ActorId = actorId
            };
            await _context.Actors_Movies.AddAsync(newActorMovie);
        }
        await _context.SaveChangesAsync();
    }
}
