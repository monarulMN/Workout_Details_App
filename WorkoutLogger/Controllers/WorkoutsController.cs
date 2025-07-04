using Microsoft.AspNetCore.Mvc;
using WorkoutLogger.Models;
using WorkoutLogger.Service;

namespace WorkoutLogger.Controllers
{
    public class WorkoutsController : Controller
    {
        private readonly WorkoutService _workoutService;

        public WorkoutsController(WorkoutService workoutService) => _workoutService = workoutService;

        public async Task<IActionResult> Index()
        {
            var sessions = await _workoutService.GetAllSessionsAsync();
            return View(sessions);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(WorkoutSession session)
        {
            if(!ModelState.IsValid) return View(session);

            await _workoutService.AddSessionAsync(session);
            return RedirectToAction(nameof(Index));
        }
    }
}
