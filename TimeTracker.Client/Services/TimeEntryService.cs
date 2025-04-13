using System.Net.Http.Json;
using TimeTracker.Shared.Dtos.TimeEntry;

namespace TimeTracker.Client.Services;

public class TimeEntryService(HttpClient http) : ITimeEntryService
{
    private readonly HttpClient _http = http;

    public int SelectedProjectId { get; set; } = 0;
    public List<TimeEntryResponse> TimeEntries { get; set; } = [];
    public event Action? OnChange;

    public async Task GetTimeEntriesByProject(int projectId)
    {
        if (projectId != SelectedProjectId)
        {
            SelectedProjectId = projectId;
            TimeEntries.Clear();
            List<TimeEntryResponse>? result = null;
            var endpoint = projectId <= 0 ? "api/timeentry" : $"api/timeentry/project/{projectId}";
            result = await _http.GetFromJsonAsync<List<TimeEntryResponse>>(endpoint);
            if (result is not null)
            {
                TimeEntries = result;
                OnChange?.Invoke();
            }
        }
    }
}
