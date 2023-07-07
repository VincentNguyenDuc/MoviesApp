using Microsoft.AspNetCore.Mvc;
using MovieApp.Services.Movies;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieApp.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using MovieApp.Data.Statics;

namespace MovieApp.Controllers;

[Authorize(Roles = UserRoles.Admin)]
public class MoviesController : Controller
{
    public readonly IMoviesService _service;
    public MoviesController(IMoviesService service)
    {
        _service = service;
    }

    [AllowAnonymous]
    public async Task<IActionResult> Index()
    {
        var allMovies = await _service.GetAllAsync(n => n.Cinema);
        return View(allMovies);
    }

    [AllowAnonymous]
    public async Task<IActionResult> Filter(string searchString)
    {
        var allMovies = await _service.GetAllAsync(n => n.Cinema);
        if (!string.IsNullOrEmpty(searchString)) {
            var filteredResult = allMovies
                .Where(n => 
                    string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) ||
                    string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase))
                .ToList();
            return View("Index", filteredResult);
        }
        return View("Index", allMovies);
    }

    [AllowAnonymous]
    public async Task<IActionResult> Details(int id) {
        var movieDetail = await _service.GetMovieByIdAsync(id);
        return View(movieDetail);
    }

    //GET: Movies/Create
    public async Task<IActionResult> Create()
    {
        var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

        ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
        ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
        ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(NewMovieViewModel movie)
    {
        if (!ModelState.IsValid)
        {
            var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

            return View(movie);
        }

        await _service.AddNewMovieAsync(movie);
        return RedirectToAction(nameof(Index));
    }

    //GET: Movies/Edit/1
    public async Task<IActionResult> Edit(int id)
    {
        var movieDetails = await _service.GetMovieByIdAsync(id);
        if (movieDetails == null) return View("NotFound");

        var response = new NewMovieViewModel()
        {
            Id = movieDetails.Id,
            Name = movieDetails.Name,
            Description = movieDetails.Description,
            StartDate = movieDetails.StartDate,
            EndDate = movieDetails.EndDate,
            ImageURL = movieDetails.ImageURL,
            MovieCategory = movieDetails.MovieCategory,
            CinemaId = movieDetails.CinemaId,
            ProducerId = movieDetails.ProducerId,
            ActorIds = movieDetails.Actors_Movies.Select(n => n.ActorId).ToList(),
        };

        var movieDropdownsData = await _service.GetNewMovieDropdownsValues();
        ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
        ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
        ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

        return View(response);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, NewMovieViewModel movie)
    {
        if (id != movie.Id) return View("NotFound");

        if (!ModelState.IsValid)
        {
            var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

            return View(movie);
        }

        await _service.UpdateMovieAsync(movie);
        return RedirectToAction(nameof(Index));
    }
}
