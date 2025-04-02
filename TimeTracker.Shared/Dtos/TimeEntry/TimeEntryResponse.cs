namespace TimeTracker.Shared.Dtos.TimeEntry;

public record struct TimeEntryResponse(
    int Id,
    string Project,
    DateTime Start,
    DateTime? End
);
