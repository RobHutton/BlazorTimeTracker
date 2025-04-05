using TimeTracker.Shared.Dtos.Project;

namespace TimeTracker.API.Services;

public interface IProjectService
{
    Task<Result<List<ProjectResponse>>> GetProjects();
    Task<Result<List<ProjectResponse>>> CreateProject(ProjectCreateRequest createRequest);
    Task<Result<List<ProjectResponse>>> UpdateProject(int id, ProjectUpdateRequest updateRequest);
    Task<Result<List<ProjectResponse>>> DeleteProject(int id);
    Task<Result<ProjectResponse>> GetProjectById(int id);
}
