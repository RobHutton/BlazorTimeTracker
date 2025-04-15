using System.ComponentModel.DataAnnotations;

namespace TimeTracker.Shared.Dtos.TimeEntry;

public class TimeEntryRequest
{
    [Range(1, int.MaxValue, ErrorMessage = "Valid project is required")]
    public int ProjectId { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime Start { get; set; } = DateTime.Now;
    public DateTime? End { get; set; }
}
