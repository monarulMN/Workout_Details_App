using Microsoft.AspNetCore.Mvc;
using WorkoutLogger.Models;
using WorkoutLogger.Service;

namespace WorkoutLogger.Controllers;

public class WorkoutsController : Controller
{
    private readonly IWorkoutService _service;

    public WorkoutsController(IWorkoutService service) => _service = service;

    public async Task<IActionResult> Index()
    {
        var sessions = await _service.GetAllSessionsAsync();
        return View(sessions);
    }

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(WorkoutSession session)
    {
        if (!ModelState.IsValid) return View(session);
        await _service.AddSessionAsync(session);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Details(int id)
    {
        var session = await _service.GetSessionByIdAsync(id);
        if (session == null) return NotFound();
        return View(session);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteSessionAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
