using ecom.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecom.Controllers;

public class CinemasController : Controller
{
    public readonly AppDbContext _context;
    public CinemasController(AppDbContext context) {
        _context = context;
    }
    public async Task<ActionResult> Index()
    {
        var allCinemas = await _context.Cinemas.ToListAsync();
        return View(allCinemas);
    }

}
