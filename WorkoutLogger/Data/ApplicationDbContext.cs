using Microsoft.EntityFrameworkCore;
using WorkoutLogger.Models;

namespace WorkoutLogger.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Exercise> Exercises => Set<Exercise>();
        public DbSet<WorkoutSession> WorkoutSessions => Set<WorkoutSession>();
        public DbSet<WorkoutSet> WorkoutSets => Set<WorkoutSet>();
    }
}
