using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.QuickGrid;
using TimeTracker.Client.Services;
using TimeTracker.Shared.Dtos.TimeEntry;

namespace TimeTracker.Client.Pages;
public partial class TimeEntries : IDisposable
{
    [Inject] ITimeEntryService TimeEntryService { get; set; } = default!;
    [Inject] NavigationManager NavigationManager { get; set; } = default!;
    private bool IsLoading { get; set; }
    private string? ErrorMessage { get; set; }
    private string? projectFilter;
    private readonly PaginationState pagination = new() { ItemsPerPage = 10 };
    IQueryable<TimeEntryResponse> FilteredTimeEntries
    {
        get
        {
            var result = TimeEntryService.TimeEntries.AsQueryable();
            if (!string.IsNullOrWhiteSpace(projectFilter))
            {
                result = result.Where(t => t.Project.Name.Contains(projectFilter, StringComparison.OrdinalIgnoreCase));
            }
            return result;
        }
    }
    protected override async Task OnInitializedAsync()
    {
        await TimeEntryService.GetTimeEntriesByProject(0);
        TimeEntryService.OnChange += StateHasChanged;
    }
    private static string GetDuration(DateTime start, DateTime? end)
    {
        var duration = (end ?? DateTime.Now) - start;
        return $"{(end.HasValue ? "" : "Ongoing: ")}{duration.Hours}h {duration.Minutes}m";
    }
    public void Dispose()
    {
        TimeEntryService.OnChange -= StateHasChanged;
        GC.SuppressFinalize(this);
    }
    private void EditTimeEntry(int id)
    {
        NavigationManager.NavigateTo($"/timeentry/{id}");
    }
    private void CreateTimeEntry()
    {
        NavigationManager.NavigateTo("/timeentry");
    }
}