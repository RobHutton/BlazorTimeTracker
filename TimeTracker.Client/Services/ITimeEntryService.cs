using TimeTracker.Shared.Dtos.TimeEntry;

namespace TimeTracker.Client.Services;

public interface ITimeEntryService
{
    event Action? OnChange;
    public List<TimeEntryResponse> TimeEntries { get; set; }
    Task<TimeEntryResponse> GetTimeEntryById(int id);
    Task GetTimeEntriesByProject(int projectId);
    Task CreateTimeEntry(TimeEntryRequest timeEntry);
    Task UpdateTimeEntry(int id, TimeEntryRequest timeEntry);
    Task DeleteTimeEntry(int id);
}
