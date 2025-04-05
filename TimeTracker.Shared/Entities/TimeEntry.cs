using System.ComponentModel.DataAnnotations;

namespace TimeTracker.Shared.Entities;

public class TimeEntry : BaseEntity
{
    // Foreign Key Property
    public int ProjectId { get; set; }

    // Navigation Property
    public Project Project { get; set; } = null!;
    [Required] // Ensures the field is not null or empty
    [MaxLength(500)] // Limits the maximum length to 500 characters
    public required string Description { get; set; }
    public DateTime Start { get; set; } = DateTime.Now;
    public DateTime? End { get; set; }

}
