using Microsoft.EntityFrameworkCore;
using WorkoutLogger.Data;
using WorkoutLogger.Models;

namespace WorkoutLogger.Repositories;

public class WorkoutRepository : IWorkoutRepositories
{
    private readonly ApplicationDbContext _dbContext;

    public WorkoutRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;

    public async Task<List<WorkoutSession>> GetAllSessionsAsync()
    => await _dbContext.WorkoutSessions.Include(s => s.Sets).ThenInclude(s => s.Exercise).ToListAsync();
    public async Task<WorkoutSession?> GetSessionByIdAsync(int id)
        => await _dbContext.WorkoutSessions.Include(s => s.Sets).ThenInclude(s => s.Exercise).FirstOrDefaultAsync(s => s.Id == id);

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
}
