using TimeTracker.Shared.Dtos.TimeEntry;

namespace TimeTracker.Client.Services;

public interface ITimeEntryService
{
    event Action? OnChange;
    public List<TimeEntryResponse> TimeEntries { get; set; }
    Task GetTimeEntriesByProject(int projectId);
}
