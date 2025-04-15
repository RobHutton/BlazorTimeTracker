using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.QuickGrid;
using TimeTracker.Client.Services;
using TimeTracker.Shared.Dtos.Project;

namespace TimeTracker.Client.Pages;
public partial class Projects : IDisposable
{
    [Inject] IProjectService ProjectService { get; set; } = default!;
    [Inject] NavigationManager NavigationManager { get; set; } = default!;
    private bool IsLoading { get; set; }
    private string? ErrorMessage { get; set; }
    private string? projectFilter;
    private readonly PaginationState pagination = new() { ItemsPerPage = 10 };
    IQueryable<ProjectResponse> FilteredProjects
    {
        get
        {
            var result = ProjectService.Projects.AsQueryable();
            if (!string.IsNullOrWhiteSpace(projectFilter))
            {
                result = result.Where(t => t.Name.Contains(projectFilter, StringComparison.OrdinalIgnoreCase));
            }
            return result;
        }
    }
    protected override async Task OnInitializedAsync()
    {
        await ProjectService.GetProjects();
        ProjectService.OnChange += StateHasChanged;
    }
    public void Dispose()
    {
        ProjectService.OnChange -= StateHasChanged;
        GC.SuppressFinalize(this);
    }
    private void EditProject(int id)
    {
        NavigationManager.NavigateTo($"/project/{id}");
    }
    private void CreateProject()
    {
        NavigationManager.NavigateTo("/project");
    }
}