using Microsoft.EntityFrameworkCore;
using WorkoutLogger.Data;
using WorkoutLogger.Models;

namespace WorkoutLogger.Repositories;

public class WorkoutRepository : IWorkoutRepository
{
    private readonly ApplicationDbContext _dbContext;

    public WorkoutRepository(ApplicationDbContext context)
    {
        _dbContext = context;
    }

    public async Task<List<WorkoutSession>> GetAllSessionsAsync()
        => await _dbContext.WorkoutSessions
            .Include(ws => ws.Sets)
            .ThenInclude(s => s.Exercise)
            .ToListAsync();

    public async Task<WorkoutSession?> GetSessionByIdAsync(int id)
        => await _dbContext.WorkoutSessions
            .Include(ws => ws.Sets)
            .ThenInclude(s => s.Exercise)
            .FirstOrDefaultAsync(ws => ws.Id == id);

    public async Task AddSessionAsync(WorkoutSession session)
    {
        _dbContext.WorkoutSessions.Add(session);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteSessionAsync(int id)
    {
        var session = await _dbContext.WorkoutSessions.FindAsync(id);
        if (session is not null)
        {
            _dbContext.WorkoutSessions.Remove(session);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task<List<Exercise>> GetAllExercisesAsync()
        => await _dbContext.Exercises.ToListAsync();

    public async Task AddExerciseAsync(Exercise exercise)
    {
        _dbContext.Exercises.Add(exercise);
        await _dbContext.SaveChangesAsync();
    }
}
