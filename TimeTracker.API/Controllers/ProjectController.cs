using TimeTracker.Shared.Dtos.Project;

namespace TimeTracker.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectController(IProjectService projectService) : ControllerBase
{
    private readonly IProjectService _projectService = projectService;

    [HttpGet]
    public async Task<ActionResult<List<ProjectResponse>>> GetProjects()
    {
        var result = await _projectService.GetProjects();
        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }
        return BadRequest(result.Error);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<List<ProjectResponse>>> GetProjectById(int id)
    {
        var result = await _projectService.GetProjectById(id);
        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }
        return BadRequest(result.Error);
    }
    [HttpPost]
    public async Task<ActionResult<List<ProjectResponse>>> CreateProject(ProjectCreateRequest createRequest)
    {
        var result = await _projectService.CreateProject(createRequest);
        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }
        return BadRequest(result.Error);
    }
    [HttpPut("{id}")]
    public async Task<ActionResult<List<ProjectResponse>>> UpdateProject(int id, ProjectUpdateRequest updateRequest)
    {
        var result = await _projectService.UpdateProject(id, updateRequest);
        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }
        return BadRequest(result.Error);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult<List<ProjectResponse>>> DeleteProject(int id)
    {
        var result = await _projectService.DeleteProject(id);
        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }
        return BadRequest(result.Error);
    }
}
