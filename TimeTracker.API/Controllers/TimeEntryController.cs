using Microsoft.AspNetCore.Mvc;
using TimeTracker.API.Services;
using TimeTracker.Shared.Dtos.TimeEntry;

namespace TimeTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeEntryController(ITimeEntryService timeEntryService) : ControllerBase
    {
        private readonly ITimeEntryService _timeEntryService = timeEntryService;

        [HttpGet]
        public ActionResult<List<TimeEntryResponse>> GetTimeEntries()
        {
            var result = _timeEntryService.GetTimeEntries();
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return BadRequest(result.Error);
        }
        [HttpGet("{id}")]
        public ActionResult<List<TimeEntryResponse>> GetTimeEntryById(int id)
        {
            var result = _timeEntryService.GetTimeEntryById(id);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return BadRequest(result.Error);
        }
        [HttpPost]
        public ActionResult<List<TimeEntryResponse>> CreateTimeEntry(TimeEntryCreateRequest createRequest)
        {
            var result = _timeEntryService.CreateTimeEntry(createRequest);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return BadRequest(result.Error);
        }
        [HttpPut("{id}")]
        public ActionResult<List<TimeEntryResponse>> UpdateTimeEntry(int id, TimeEntryUpdateRequest updateRequest)
        {
            var result = _timeEntryService.UpdateTimeEntry(id, updateRequest);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return BadRequest(result.Error);
        }
        [HttpDelete("{id}")]
        public ActionResult<List<TimeEntryResponse>> DeleteTimeEntry(int id)
        {
            var result = _timeEntryService.DeleteTimeEntry(id);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return BadRequest(result.Error);
        }
    }
}
