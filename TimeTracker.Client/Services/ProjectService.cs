using Mapster;
using System.Net.Http.Json;
using TimeTracker.Shared.Dtos.Project;

namespace TimeTracker.Client.Services;

public class ProjectService(HttpClient http) : IProjectService
{
    private readonly HttpClient _http = http;
    public List<ProjectResponse> Projects { get; set; } = [];
    public event Action? OnChange;

    public async Task GetProjects()
    {
        var result = await _http.GetFromJsonAsync<List<ProjectResponse>>($"api/project");
        if (result is not null)
        {
            Projects = result;
            OnChange?.Invoke();
        }
    }
    public async Task<ProjectResponse> GetProjectById(int id)
    {
        return await _http.GetFromJsonAsync<ProjectResponse>($"api/project/{id}");
    }
    public async Task CreateProject(ProjectRequest project)
    {
        await _http.PostAsJsonAsync("api/project", project.Adapt<ProjectCreateRequest>());
    }
    public async Task UpdateProject(int id, ProjectRequest project)
    {
        await _http.PutAsJsonAsync($"api/project/{id}", project.Adapt<ProjectUpdateRequest>());
    }
    public async Task DeleteProject(int id)
    {
        await _http.DeleteAsync($"api/project/{id}");
    }
}
