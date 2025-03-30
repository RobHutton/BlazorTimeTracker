using TimeTracker.Shared.Entities;
namespace TimeTracker.API.Repositories;

public class TimeEntryRepository : ITimeEntryRepository
{
    private static List<TimeEntry> _timeEntries =
    [
        new TimeEntry { Id = 1, Project = "Time Tracker App", End = DateTime.Now.AddDays(7) },
                new TimeEntry { Id = 2, Project = "Time Tracker App", Start = DateTime.Now.AddDays(1), End = DateTime.Now.AddDays(2) },
                new TimeEntry { Id = 3, Project = "Time Tracker App", Start = DateTime.Now.AddDays(2), End = DateTime.Now.AddDays(3) },
                new TimeEntry { Id = 4, Project = "Time Tracker App", Start = DateTime.Now.AddDays(3), End = DateTime.Now.AddDays(4) },
                new TimeEntry { Id = 5, Project = "Time Tracker App", Start = DateTime.Now.AddDays(4), End = DateTime.Now.AddDays(5) }
    ];
    public List<TimeEntry> GetTimeEntries()
    {
        return _timeEntries;
    }
    public List<TimeEntry> CreateTimeEntry(TimeEntry timeEntry)
    {
        _timeEntries.Add(timeEntry);
        return _timeEntries;
    }
    public List<TimeEntry>? UpdateTimeEntry(int id, TimeEntry timeEntry)
    {
        var updateIndex = _timeEntries.FindIndex(t => t.Id == id);
        if (_timeEntries[updateIndex] is null)
        {
            return null;
        }
        _timeEntries[updateIndex] = timeEntry;
        return _timeEntries;
    }

    public List<TimeEntry>? DeleteTimeEntry(int id)
    {
        var deleteIndex = _timeEntries.FindIndex(t => t.Id == id);
        if (_timeEntries[deleteIndex] is null)
        {
            return null;
        }
        _timeEntries[deleteIndex].IsDeleted = true;
        return _timeEntries;
    }

    public TimeEntry? GetTimeEntryById(int id)
    {
        return _timeEntries.FirstOrDefault(e => e.Id == id);
    }
}
