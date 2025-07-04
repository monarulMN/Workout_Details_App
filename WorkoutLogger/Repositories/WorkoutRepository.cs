using WorkoutLogger.Data;

namespace WorkoutLogger.Repositories
{
    public class WorkoutRepository :IWorkoutRepositories
    {
        private readonly ApplicationDbContext _dbContext;

        public WorkoutRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;


    }
}
