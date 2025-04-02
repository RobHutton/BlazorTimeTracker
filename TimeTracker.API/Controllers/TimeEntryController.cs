global using Microsoft.AspNetCore.Mvc;

namespace TimeTracker.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TimeEntryController(ITimeEntryService timeEntryService) : ControllerBase
{
    private readonly ITimeEntryService _timeEntryService = timeEntryService;

    [HttpGet]
    public async Task<ActionResult<List<TimeEntryResponse>>> GetTimeEntries()
    {
        var result = await _timeEntryService.GetTimeEntries();
        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }
        return BadRequest(result.Error);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<List<TimeEntryResponse>>> GetTimeEntryById(int id)
    {
        var result = await _timeEntryService.GetTimeEntryById(id);
        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }
        return BadRequest(result.Error);
    }
    [HttpPost]
    public async Task<ActionResult<List<TimeEntryResponse>>> CreateTimeEntry(TimeEntryCreateRequest createRequest)
    {
        var result = await _timeEntryService.CreateTimeEntry(createRequest);
        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }
        return BadRequest(result.Error);
    }
    [HttpPut("{id}")]
    public async Task<ActionResult<List<TimeEntryResponse>>> UpdateTimeEntry(int id, TimeEntryUpdateRequest updateRequest)
    {
        var result = await _timeEntryService.UpdateTimeEntry(id, updateRequest);
        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }
        return BadRequest(result.Error);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult<List<TimeEntryResponse>>> DeleteTimeEntry(int id)
    {
        var result = await _timeEntryService.DeleteTimeEntry(id);
        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }
        return BadRequest(result.Error);
    }
}
