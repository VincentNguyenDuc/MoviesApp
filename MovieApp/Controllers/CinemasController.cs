using MovieApp.Models.FeatureModels;
using MovieApp.Services.Cinemas;
using Microsoft.AspNetCore.Mvc;

namespace MovieApp.Controllers;

public class CinemasController : Controller
{
    public readonly ICinemasService _service;
    public CinemasController(ICinemasService service)
    {
        _service = service;
    }
    public async Task<ActionResult> Index()
    {
        var allCinemas = await _service.GetAllAsync();
        return View(allCinemas);
    }

    // Create: Cinemas/Create
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create([Bind("Name,Logo,Description")] Cinema cinema)
    {
        if (!ModelState.IsValid)
        {
            return View(cinema);
        }
        await _service.AddAsync(cinema);
        return RedirectToAction(nameof(Index));
    }

    // Read: Cinemas/Details/{id}
    public async Task<IActionResult> Details(int id)
    {
        var cinemaDetails = await _service.GetByIdAsync(id);
        if (cinemaDetails == null)
        {
            return View("NotFound");
        }
        return View(cinemaDetails);
    }

    // Update: Cinemas/Edit/{id}
    public async Task<IActionResult> Edit(int id)
    {
        var cinemaDetails = await _service.GetByIdAsync(id);
        if (cinemaDetails == null)
        {
            return View("NotFound");
        }
        return View(cinemaDetails);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Logo,Description")] Cinema cinema)
    {
        if (!ModelState.IsValid)
        {
            return View(cinema);
        }
        await _service.UpdateAsync(id, cinema);
        return RedirectToAction(nameof(Index));
    }

    // Delete: Cinemas/Delete/{id}
    public async Task<IActionResult> Delete(int id)
    {
        var cinemaDetails = await _service.GetByIdAsync(id);
        if (cinemaDetails == null)
        {
            return View("NotFound");
        }
        return View(cinemaDetails);
    }
    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var cinemaDetails = await _service.GetByIdAsync(id);
        if (cinemaDetails == null)
        {
            return View("NotFound");
        }
        await _service.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}

