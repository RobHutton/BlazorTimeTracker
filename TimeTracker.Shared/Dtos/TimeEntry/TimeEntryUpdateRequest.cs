namespace TimeTracker.Shared.Dtos.TimeEntry;

public record struct TimeEntryUpdateRequest(
    string Project,
    DateTime Start,
    DateTime? End
)
{
    // Mark 'Project' as required
    public required string Project { get; init; } = Project;

    // If you want to set a default value for Start, it will be handled in the constructor
    public DateTime Start { get; init; } = Start == default ? DateTime.Now : Start;
}

