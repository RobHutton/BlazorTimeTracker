namespace TimeTracker.Shared.Dtos.TimeEntry;

public record struct TimeEntryProjectResponse(
    int Id,
    string Description,
    DateTime Start,
    DateTime? End
);
