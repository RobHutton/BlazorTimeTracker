namespace TimeTracker.Shared.Entities
{
    public class TimeEntry : BaseEntity
    {
        public int Id { get; set; }
        public required string Project { get; set; }
        public DateTime Start { get; set; } = DateTime.Now;
        public DateTime? End { get; set; }

    }
}
