using WorkoutLogger.Models;
using WorkoutLogger.Repositories;
using WorkoutLogger.Service;

namespace WorkoutLogger.Service;

public class WorkoutService : IWorkoutService
{
    private readonly IWorkoutRepository _repo;

    public WorkoutService(IWorkoutRepository repo)
    {
        _repo = repo;
    }

    public Task<List<WorkoutSession>> GetAllSessionsAsync() => _repo.GetAllSessionsAsync();

    public Task<WorkoutSession?> GetSessionByIdAsync(int id) => _repo.GetSessionByIdAsync(id);

    public Task AddSessionAsync(WorkoutSession session) => _repo.AddSessionAsync(session);

    public Task DeleteSessionAsync(int id) => _repo.DeleteSessionAsync(id);

    public Task<List<Exercise>> GetAllExercisesAsync() => _repo.GetAllExercisesAsync();

    public Task AddExerciseAsync(Exercise exercise) => _repo.AddExerciseAsync(exercise);
}

