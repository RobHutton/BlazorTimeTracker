namespace TimeTracker.API.Repositories;

public class ProjectRepository(DataContext dbContext) : IProjectRepository
{
    private readonly DataContext _dbContext = dbContext;

    public async Task<List<Project>> GetProjects()
    {
        return await _dbContext.Projects
            .Where(p => !p.IsDeleted)
            .Include(p => p.TimeEntries.Where(t => !t.IsDeleted))
            .ToListAsync();
    }
    public async Task<Project?> GetProjectById(int id)
    {
        return await _dbContext.Projects
            .Include(p => p.TimeEntries.Where(t => !t.IsDeleted))
            .FirstOrDefaultAsync(p => p.Id == id);
    }
    public async Task<List<Project>> CreateProject(Project project)
    {

        _dbContext.Projects.Add(project);
        await _dbContext.SaveChangesAsync();
        return await GetProjects();
    }
    public async Task<List<Project>> UpdateProject(int id, Project project)
    {
        var updateEntry = await GetProjectById(id) ?? throw new EntityNotFoundException();

        // Update the properties
        updateEntry.Name = project.Name;
        updateEntry.Updated = DateTime.Now;

        // Save changes if using EF
        await _dbContext.SaveChangesAsync();  // Add this line if using EF

        // Return the updated list
        return await GetProjects();  // Return updated list from DB
    }
    public async Task<List<Project>> DeleteProject(int id)
    {
        var deleteEntry = await GetProjectById(id) ?? throw new EntityNotFoundException();

        // Update the properties
        deleteEntry.IsDeleted = true;
        deleteEntry.Deleted = DateTime.Now;

        // Save changes if using EF
        await _dbContext.SaveChangesAsync();  // Add this line if using EF

        // Return the updated list
        return await GetProjects();  // Return updated list from DB
    }
}
