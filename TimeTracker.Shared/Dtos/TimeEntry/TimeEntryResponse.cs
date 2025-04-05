using TimeTracker.Shared.Dtos.Project;

namespace TimeTracker.Shared.Dtos.TimeEntry;

public record struct TimeEntryResponse(
    int Id,
    string Description,
    DateTime Start,
    DateTime? End,
    TimeEntryProjectResponse Project
);
