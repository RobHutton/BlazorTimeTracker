namespace TimeTracker.Shared.Dtos.TimeEntry;

public class TimeEntryCreateRequest
{
    public required string Project { get; set; }
    public DateTime Start { get; set; } = DateTime.Now;
    public DateTime? End { get; set; }
}
