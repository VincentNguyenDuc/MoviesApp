﻿using MovieApp.Models.FeatureModels;
using MovieApp.Services.Producers;
using MovieApp.Data.Statics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace MovieApp.Controllers;

[Authorize(Roles =UserRoles.Admin)]
public class ProducersController : Controller
{
    private readonly IProducersService _service;

    public ProducersController(IProducersService service) {
        _service = service;
    }

    [AllowAnonymous]
    public async Task<IActionResult> Index()
    {
        var allProducers = await _service.GetAllAsync();
        return View(allProducers);
    }

    // Create: Producers/Create
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([Bind("ProfilePictureURL,FullName,Bio")]Producer producer)
    {
        if (!ModelState.IsValid)
        {
            return View(producer);
        }
        await _service.AddAsync(producer);
        return RedirectToAction(nameof(Index));
    }

    [AllowAnonymous]
    // Read: Producers/Details/{id}
    public async Task<IActionResult> Details(int id)
    {
        var producerDetails = await _service.GetByIdAsync(id);
        if (producerDetails == null)
        {
            return View("NotFound");
        }
        return View(producerDetails);
    }

    // Update: Producers/Edit/{id}
    public async Task<IActionResult> Edit(int id)
    {
        var producerDetails = await _service.GetByIdAsync(id);
        if (producerDetails == null)
        {
            return View("NotFound");
        }
        return View(producerDetails);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePictureURL,FullName,Bio")] Producer producer)
    {
        if (!ModelState.IsValid)
        {
            return View(producer);
        }
        if (id == producer.Id) {
            await _service.UpdateAsync(id, producer);
            return RedirectToAction(nameof(Index));
        }
        return View(producer);
    }

    // Delete: Producers/Delete/{id}
    public async Task<IActionResult> Delete(int id)
    {
        var producerDetails = await _service.GetByIdAsync(id);
        if (producerDetails == null)
        {
            return View("NotFound");
        }
        return View(producerDetails);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var producerDetails = await _service.GetByIdAsync(id);
        if (producerDetails == null)
        {
            return View("NotFound");
        }
        await _service.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
