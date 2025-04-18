﻿namespace TimeTracker.API.Repositories;

public class TimeEntryRepository(DataContext dbContext) : ITimeEntryRepository
{
    private readonly DataContext _dbContext = dbContext;

    public async Task<List<TimeEntry>> GetTimeEntries()
    {
        return await _dbContext.TimeEntries.Where(e => !e.IsDeleted).ToListAsync();
    }
    public async Task<TimeEntry?> GetTimeEntryById(int id)
    {
        return await _dbContext.TimeEntries.FindAsync(id);
    }
    public async Task<List<TimeEntry>> GetTimeEntriesByProjectId(int projectId)
    {
        return await _dbContext.TimeEntries.Where(t => t.ProjectId == projectId && !t.IsDeleted).ToListAsync();
    }
    public async Task<List<TimeEntry>> CreateTimeEntry(TimeEntry timeEntry)
    {

        _dbContext.TimeEntries.Add(timeEntry);
        await _dbContext.SaveChangesAsync();
        return await GetTimeEntries();
    }
    public async Task<List<TimeEntry>> UpdateTimeEntry(int id, TimeEntry timeEntry)
    {
        var updateEntry = await GetTimeEntryById(id) ?? throw new EntityNotFoundException();

        // Update the properties
        updateEntry.ProjectId = timeEntry.ProjectId;
        updateEntry.Start = timeEntry.Start;
        updateEntry.End = timeEntry.End;
        updateEntry.Updated = DateTime.Now;

        // Save changes if using EF
        await _dbContext.SaveChangesAsync();  // Add this line if using EF

        // Return the updated list
        return await GetTimeEntries();  // Return updated list from DB
    }
    public async Task<List<TimeEntry>> DeleteTimeEntry(int id)
    {
        var deleteEntry = await GetTimeEntryById(id) ?? throw new EntityNotFoundException();

        // Update the properties
        deleteEntry.IsDeleted = true;
        deleteEntry.Deleted = DateTime.Now;

        // Save changes if using EF
        await _dbContext.SaveChangesAsync();  // Add this line if using EF

        // Return the updated list
        return await GetTimeEntries();  // Return updated list from DB
    }
}
