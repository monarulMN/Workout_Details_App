using Microsoft.EntityFrameworkCore;
using WorkoutLogger.Data;
using WorkoutLogger.Models;
using WorkoutLogger.Repositories;

namespace WorkoutLogger.Service;

public class WorkoutService :IWorkoutService
{
    private readonly IWorkoutRepository _repo;

    public WorkoutService(IWorkoutRepository repo) => _repo = repo;

    public Task<List<WorkoutSession>> GetAllSessionsAsync() => _repo.GetAllSessionsAsync();
    public Task<WorkoutSession?> GetSessionByIdAsync(int id) => _repo.GetSessionByIdAsync(id);
    public Task AddSessionAsync(WorkoutSession session) => _repo.AddSessionAsync(session);
    public Task DeleteSessionAsync(int id) => _repo.DeleteSessionAsync(id);
}
