using Microsoft.EntityFrameworkCore;
using WorkoutLogger.Data;
using WorkoutLogger.Models;

namespace WorkoutLogger.Service
{
    public class WorkoutService
    {
        private readonly ApplicationDbContext _dbContext;

        public WorkoutService(ApplicationDbContext dbContext) => _dbContext = dbContext;

        public async Task<List<WorkoutSession>> GetAllSessionsAsync()
            => await _dbContext.WorkoutSessions.Include(s => s.Sets).ThenInclude(s => s.Exercise).ToListAsync();

        public async Task AddSessionAsync(WorkoutSession session)
        {
            _dbContext.WorkoutSessions.Add(session);
            await _dbContext.SaveChangesAsync();
        }
    }
}
