using TimeTracker.Shared.Dtos.TimeEntry;
using TimeTracker.Shared.Models;

namespace TimeTracker.API.Services;

public interface ITimeEntryService
{
    Result<List<TimeEntryResponse>> GetTimeEntries();
    Result<List<TimeEntryResponse>> CreateTimeEntry(TimeEntryCreateRequest createRequest);
    Result<List<TimeEntryResponse>> UpdateTimeEntry(int id, TimeEntryUpdateRequest updateRequest);
    Result<List<TimeEntryResponse>> DeleteTimeEntry(int id);
    Result<TimeEntryResponse> GetTimeEntryById(int id);
}
