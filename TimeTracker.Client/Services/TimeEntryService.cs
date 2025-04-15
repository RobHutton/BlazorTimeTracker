using Mapster;
using System.Net.Http.Json;
using TimeTracker.Shared.Dtos.TimeEntry;

namespace TimeTracker.Client.Services;

public class TimeEntryService(HttpClient http) : ITimeEntryService
{
    private readonly HttpClient _http = http;

    public int SelectedProjectId { get; set; } = -1;
    public List<TimeEntryResponse> TimeEntries { get; set; } = [];
    public event Action? OnChange;

    public async Task CreateTimeEntry(TimeEntryRequest timeEntry)
    {
        await _http.PostAsJsonAsync("api/timeentry", timeEntry.Adapt<TimeEntryCreateRequest>());
    }
    public async Task UpdateTimeEntry(int id, TimeEntryRequest timeEntry)
    {
        await _http.PutAsJsonAsync($"api/timeentry/{id}", timeEntry.Adapt<TimeEntryUpdateRequest>());
    }
    public async Task DeleteTimeEntry(int id)
    {
        await _http.DeleteAsync($"api/timeentry/{id}");
    }
    public async Task GetTimeEntriesByProject(int projectId)
    {
        if (projectId != SelectedProjectId)
        {
            SelectedProjectId = projectId;
        }
        TimeEntries.Clear();
        var endpoint = projectId <= 0 ? "api/timeentry" : $"api/timeentry/project/{projectId}";
        List<TimeEntryResponse>? result = await _http.GetFromJsonAsync<List<TimeEntryResponse>>(endpoint);
        if (result is not null)
        {
            TimeEntries = result;
        }
        OnChange?.Invoke();
    }

    public async Task<TimeEntryResponse> GetTimeEntryById(int id)
    {
        return await _http.GetFromJsonAsync<TimeEntryResponse>($"api/timeentry/{id}");
    }

}
