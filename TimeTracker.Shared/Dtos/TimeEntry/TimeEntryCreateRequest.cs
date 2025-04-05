namespace TimeTracker.Shared.Dtos.TimeEntry;

public record struct TimeEntryCreateRequest(
    int ProjectId,
    string Description,
    DateTime Start,
    DateTime? End
)
{
    // Mark 'ProjectId' as required
    public required int ProjectId { get; init; } = ProjectId;
    // Mark 'Description' as required
    public required string Description { get; init; } = Description;

    // If you want to set a default value for Start, it will be handled in the constructor
    public DateTime Start { get; init; } = Start == default ? DateTime.Now : Start;
}
