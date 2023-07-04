using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ecom.Data;

namespace ecom.Controllers;

public class MoviesController : Controller
{
    public readonly AppDbContext _context;
    public MoviesController(AppDbContext context)
    {
        _context = context;
    }
    public async Task<ActionResult> Index()
    {
        var allMovies = await _context
                                .Movies
                                .Include(n => n.Cinema)
                                .OrderBy(n => n.Name)
                                .ToListAsync();
        return View(allMovies);
    }
}
