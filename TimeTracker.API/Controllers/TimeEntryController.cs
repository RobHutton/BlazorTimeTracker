using Microsoft.AspNetCore.Mvc;
using TimeTracker.Shared.Entities;

namespace TimeTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeEntryController : ControllerBase
    {
        private static readonly List<TimeEntry> _timeEntries =
        [
            new TimeEntry { Id = 1, Project = "Time Tracker App", End = DateTime.Now.AddDays(7) },
            new TimeEntry { Id = 2, Project = "Time Tracker App", Start = DateTime.Now.AddDays(1), End = DateTime.Now.AddDays(2) },
            new TimeEntry { Id = 3, Project = "Time Tracker App", Start = DateTime.Now.AddDays(2), End = DateTime.Now.AddDays(3) },
            new TimeEntry { Id = 4, Project = "Time Tracker App", Start = DateTime.Now.AddDays(3), End = DateTime.Now.AddDays(4) },
            new TimeEntry { Id = 5, Project = "Time Tracker App", Start = DateTime.Now.AddDays(4), End = DateTime.Now.AddDays(5) }
        ];
        [HttpGet]
        public ActionResult<List<TimeEntry>> GetAllTimeEntries()
        {
            return Ok(_timeEntries);
        }
    }
}
