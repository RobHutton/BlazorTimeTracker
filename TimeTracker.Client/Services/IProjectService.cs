using TimeTracker.Shared.Dtos.Project;

namespace TimeTracker.Client.Services;

public interface IProjectService
{
    public List<ProjectResponse> Projects { get; set; }
    event Action? OnChange;
    public Task GetProjects();
    Task<ProjectResponse> GetProjectById(int id);
    Task CreateProject(ProjectRequest project);
    Task UpdateProject(int id, ProjectRequest project);
    Task DeleteProject(int id);
}
