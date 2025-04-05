namespace TimeTracker.Shared.Dtos.TimeEntry;

public record struct TimeEntryUpdateRequest(
    string Description,
    DateTime Start,
    DateTime? End
)
{
    // Mark 'Description' as required
    public required string Description { get; init; } = Description;

    // If you want to set a default value for Start, it will be handled in the constructor
    public DateTime Start { get; init; } = Start == default ? DateTime.Now : Start;
}

