using Mapster;

namespace TimeTracker.API.Services;

public class TimeEntryService(ITimeEntryRepository timeEntryRepository, ILogger<TimeEntryService> logger) : ITimeEntryService
{
    private readonly ITimeEntryRepository _timeEntryRepository = timeEntryRepository;
    private readonly ILogger<TimeEntryService> _logger = logger;

    public async Task<Result<List<TimeEntryResponse>>> GetTimeEntries()
    {
        try
        {
            var result = await _timeEntryRepository.GetTimeEntries();
            var response = result.Adapt<List<TimeEntryResponse>>();
            return Result<List<TimeEntryResponse>>.Success(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{error}", Error.GetTimeEntries);
            return Result<List<TimeEntryResponse>>.Fail(Error.GetTimeEntries);
        }
    }

    public async Task<Result<List<TimeEntryResponse>>> CreateTimeEntry(TimeEntryCreateRequest createRequest)
    {
        try
        {
            var newEntry = createRequest.Adapt<TimeEntry>();
            var result = await _timeEntryRepository.CreateTimeEntry(newEntry);
            var response = result.Adapt<List<TimeEntryResponse>>();
            return Result<List<TimeEntryResponse>>.Success(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{error}", Error.CreateTimeEntry);
            return Result<List<TimeEntryResponse>>.Fail(Error.CreateTimeEntry);
        }
    }

    public async Task<Result<List<TimeEntryResponse>>> UpdateTimeEntry(int id, TimeEntryUpdateRequest updateRequest)
    {
        try
        {
            var timeEntry = updateRequest.Adapt<TimeEntry>();
            var result = await _timeEntryRepository.UpdateTimeEntry(id, timeEntry);
            var response = result.Adapt<List<TimeEntryResponse>>();
            return Result<List<TimeEntryResponse>>.Success(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{error}", Error.UpdateTimeEntry);
            return Result<List<TimeEntryResponse>>.Fail(Error.UpdateTimeEntry);
        }
    }

    public async Task<Result<List<TimeEntryResponse>>> DeleteTimeEntry(int id)
    {
        try
        {
            var result = await _timeEntryRepository.DeleteTimeEntry(id);
            var response = result.Adapt<List<TimeEntryResponse>>();
            return Result<List<TimeEntryResponse>>.Success(response);
        }
        catch (EntityNotFoundException ex)
        {
            _logger.LogError(ex, "{error}", Error.DeleteTimeEntry);
            return Result<List<TimeEntryResponse>>.Fail(Error.DeleteTimeEntry);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{error}", Error.DeleteTimeEntry);
            return Result<List<TimeEntryResponse>>.Fail(Error.DeleteTimeEntry);
        }
    }

    public async Task<Result<TimeEntryResponse>> GetTimeEntryById(int id)
    {
        try
        {
            var result = await _timeEntryRepository.GetTimeEntryById(id);
            if (result is null)
            {
                return Result<TimeEntryResponse>.Fail(Error.GetTimeEntryById);
            }
            var response = result.Adapt<TimeEntryResponse>();
            return Result<TimeEntryResponse>.Success(response);
        }
        catch (EntityNotFoundException ex)
        {
            _logger.LogError(ex, "{error}", Error.GetTimeEntryById);
            return Result<TimeEntryResponse>.Fail(Error.GetTimeEntryById);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{error}", Error.GetTimeEntryById);
            return Result<TimeEntryResponse>.Fail(Error.GetTimeEntryById);
        }
    }
}
