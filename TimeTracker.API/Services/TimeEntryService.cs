using Mapster;
using TimeTracker.API.Repositories;
using TimeTracker.Shared.Dtos.TimeEntry;
using TimeTracker.Shared.Entities;
using TimeTracker.Shared.Models;

namespace TimeTracker.API.Services;

public class TimeEntryService(ITimeEntryRepository timeEntryRepository) : ITimeEntryService
{
    private readonly ITimeEntryRepository _timeEntryRepository = timeEntryRepository;

    public Result<List<TimeEntryResponse>> GetTimeEntries()
    {
        var result = _timeEntryRepository.GetTimeEntries();
        var response = result.Adapt<List<TimeEntryResponse>>();
        return Result<List<TimeEntryResponse>>.Success(response);
    }

    public Result<List<TimeEntryResponse>> CreateTimeEntry(TimeEntryCreateRequest createRequest)
    {
        var newEntry = createRequest.Adapt<TimeEntry>();
        var result = _timeEntryRepository.CreateTimeEntry(newEntry);
        var response = result.Adapt<List<TimeEntryResponse>>();
        return Result<List<TimeEntryResponse>>.Success(response);
    }

    public Result<List<TimeEntryResponse>> UpdateTimeEntry(int id, TimeEntryUpdateRequest updateRequest)
    {
        var timeEntry = updateRequest.Adapt<TimeEntry>();
        var result = _timeEntryRepository.UpdateTimeEntry(id, timeEntry);
        if (result is null)
        {
            return Result<List<TimeEntryResponse>>.Fail($"Failed to Update Time Entry for Id {id}");
        }
        var response = result.Adapt<List<TimeEntryResponse>>();
        return Result<List<TimeEntryResponse>>.Success(response);
    }

    public Result<List<TimeEntryResponse>> DeleteTimeEntry(int id)
    {
        var result = _timeEntryRepository.DeleteTimeEntry(id);
        if (result is null)
        {
            return Result<List<TimeEntryResponse>>.Fail($"Failed to Update Time Entry for Id {id}");
        }
        var response = result.Adapt<List<TimeEntryResponse>>();
        return Result<List<TimeEntryResponse>>.Success(response);
    }

    public Result<TimeEntryResponse> GetTimeEntryById(int id)
    {
        var result = _timeEntryRepository.GetTimeEntryById(id);
        if (result is null)
        {
            return Result<TimeEntryResponse>.Fail($"Failed to Find Time Entry for Id {id}");
        }
        var response = result.Adapt<TimeEntryResponse>();
        return Result<TimeEntryResponse>.Success(response);
    }
}
