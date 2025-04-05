using System.ComponentModel.DataAnnotations;

namespace TimeTracker.Shared.Entities
{
    public class Project : BaseEntity
    {
        [Required] // Ensures the field is not null or empty
        [MaxLength(100)] // Limits the maximum length to 100 characters
        public required string Name { get; set; }
        // One-to-Many Relationship
        public List<TimeEntry> TimeEntries { get; set; } = [];
    }
}
