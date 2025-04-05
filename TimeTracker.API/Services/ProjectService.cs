using Mapster;
using TimeTracker.Shared.Dtos.Project;

namespace TimeTracker.API.Services;

public class ProjectService(IProjectRepository projectRepository, ILogger<ProjectService> logger) : IProjectService
{
    private readonly IProjectRepository _projectRepository = projectRepository;
    private readonly ILogger<ProjectService> _logger = logger;

    public async Task<Result<List<ProjectResponse>>> GetProjects()
    {
        try
        {
            var result = await _projectRepository.GetProjects();
            var response = result.Adapt<List<ProjectResponse>>();
            return Result<List<ProjectResponse>>.Success(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{error}", Error.GetProjects);
            return Result<List<ProjectResponse>>.Fail($"{Error.GetProjects}: {ex.Message}");
        }
    }

    public async Task<Result<List<ProjectResponse>>> CreateProject(ProjectCreateRequest createRequest)
    {
        try
        {
            var newEntry = createRequest.Adapt<Project>();
            var result = await _projectRepository.CreateProject(newEntry);
            var response = result.Adapt<List<ProjectResponse>>();
            return Result<List<ProjectResponse>>.Success(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{error}", Error.CreateProject);
            return Result<List<ProjectResponse>>.Fail($"{Error.CreateProject}: {ex.Message}");
        }
    }

    public async Task<Result<List<ProjectResponse>>> UpdateProject(int id, ProjectUpdateRequest updateRequest)
    {
        try
        {
            var updateProject = updateRequest.Adapt<Project>();
            var result = await _projectRepository.UpdateProject(id, updateProject);
            var response = result.Adapt<List<ProjectResponse>>();
            return Result<List<ProjectResponse>>.Success(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{error}", Error.UpdateProject);
            return Result<List<ProjectResponse>>.Fail($"{Error.UpdateProject}: {ex.Message}");
        }
    }

    public async Task<Result<List<ProjectResponse>>> DeleteProject(int id)
    {
        try
        {
            var result = await _projectRepository.DeleteProject(id);
            var response = result.Adapt<List<ProjectResponse>>();
            return Result<List<ProjectResponse>>.Success(response);
        }
        catch (EntityNotFoundException ex)
        {
            _logger.LogError(ex, "{error}", Error.DeleteProject);
            return Result<List<ProjectResponse>>.Fail($"{Error.DeleteProject}: {ex.Message}");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{error}", Error.DeleteProject);
            return Result<List<ProjectResponse>>.Fail($"{Error.DeleteProject}: {ex.Message}");
        }
    }

    public async Task<Result<ProjectResponse>> GetProjectById(int id)
    {
        try
        {
            var result = await _projectRepository.GetProjectById(id);
            if (result is null)
            {
                return Result<ProjectResponse>.Fail(Error.GetProjectById);
            }
            var response = result.Adapt<ProjectResponse>();
            return Result<ProjectResponse>.Success(response);
        }
        catch (EntityNotFoundException ex)
        {
            _logger.LogError(ex, "{error}", Error.GetProjectById);
            return Result<ProjectResponse>.Fail($"{Error.GetProjectById}: {ex.Message}");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{error}", Error.GetProjectById);
            return Result<ProjectResponse>.Fail($"{Error.GetProjectById}: {ex.Message}");
        }
    }
}
