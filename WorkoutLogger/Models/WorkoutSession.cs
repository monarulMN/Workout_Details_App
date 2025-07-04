namespace WorkoutLogger.Models
{
    public class WorkoutSession
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public ICollection<WorkoutSet> Sets { get; set; } = new List<WorkoutSet>();
    }
}
