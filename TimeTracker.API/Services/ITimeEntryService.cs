namespace TimeTracker.API.Services;

public interface ITimeEntryService
{
    Task<Result<List<TimeEntryResponse>>> GetTimeEntries();
    Task<Result<List<TimeEntryResponse>>> CreateTimeEntry(TimeEntryCreateRequest createRequest);
    Task<Result<List<TimeEntryResponse>>> UpdateTimeEntry(int id, TimeEntryUpdateRequest updateRequest);
    Task<Result<List<TimeEntryResponse>>> DeleteTimeEntry(int id);
    Task<Result<TimeEntryResponse>> GetTimeEntryById(int id);
}
