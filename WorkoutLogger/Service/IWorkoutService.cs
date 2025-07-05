using WorkoutLogger.Models;

namespace WorkoutLogger.Service;

public interface IWorkoutService
{
    Task<List<WorkoutSession>> GetAllSessionsAsync();
    Task<WorkoutSession?> GetSessionByIdAsync(int id);
    Task AddSessionAsync(WorkoutSession session);
    Task DeleteSessionAsync(int id);

    Task<List<Exercise>> GetAllExercisesAsync();
    Task AddExerciseAsync(Exercise exercise);
}
