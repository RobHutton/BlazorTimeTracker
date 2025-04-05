using TimeTracker.Shared.Dtos.TimeEntry;

namespace TimeTracker.Shared.Dtos.Project;

public record struct ProjectResponse
(
    int Id,
    string Name,
    List<TimeEntryResponse> TimeEntries
);

