namespace WorkoutLogger.Models
{
    public class WorkoutSet
    {
        public int Id { get; set; }
        public int Reps { get; set; }
        public decimal Weight { get; set; }

        public int ExerciseId { get; set; }
        public Exercise? Exercise { get; set; } = null!;

        public int WorkoutSessionId { get; set; }
        public WorkoutSession? WorkoutSession { get; set; } = null!;

    }
}
