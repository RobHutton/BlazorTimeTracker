namespace TimeTracker.API.Repositories;

public interface IProjectRepository
{
    Task<List<Project>> GetProjects();
    Task<Project?> GetProjectById(int id);
    Task<List<Project>> CreateProject(Project project);
    Task<List<Project>> UpdateProject(int id, Project project);
    Task<List<Project>> DeleteProject(int id);
}
