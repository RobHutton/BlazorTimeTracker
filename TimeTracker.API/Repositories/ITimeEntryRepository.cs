namespace TimeTracker.API.Repositories;

public interface ITimeEntryRepository
{
    Task<List<TimeEntry>> GetTimeEntries();
    Task<TimeEntry?> GetTimeEntryById(int id);
    Task<List<TimeEntry>> GetTimeEntriesByProjectId(int projectId);
    Task<List<TimeEntry>> CreateTimeEntry(TimeEntry timeEntry);
    Task<List<TimeEntry>> UpdateTimeEntry(int id, TimeEntry timeEntry);
    Task<List<TimeEntry>> DeleteTimeEntry(int id);
}
