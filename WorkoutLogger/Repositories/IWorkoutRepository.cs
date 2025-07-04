using WorkoutLogger.Models;

namespace WorkoutLogger.Repositories;

public interface IWorkoutRepository
{
    Task<List<WorkoutSession>> GetAllSessionsAsync();
    Task<WorkoutSession> GetSessionByIdasync(int id);
    Task AddSessionAsync(WorkoutSession session);
    Task DeleteSessionAsync(int id);
}
