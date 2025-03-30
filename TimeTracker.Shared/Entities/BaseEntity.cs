namespace TimeTracker.Shared.Entities
{
    public class BaseEntity
    {
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime? Updated { get; set; }
        public bool IsDeleted { get; set; }
    }
}
