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

    public async Task<IActionResult> Create()
    {
        ViewBag.Exercises = await _service.GetAllExercisesAsync();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(WorkoutSession session, List<WorkoutSet> sets)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Exercises = await _service.GetAllExercisesAsync();
            return View(session);
        }

        session.Sets = sets;
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



    public IActionResult Charts()
    {
        return View();
    }

    
    public IActionResult AddExercise() => View();

    [HttpPost]
    public async Task<IActionResult> AddExercise(Exercise exercise)
    {
        if (!ModelState.IsValid) return View(exercise);
        await _service.AddExerciseAsync(exercise);
        return RedirectToAction(nameof(Create));
    }
}
