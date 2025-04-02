namespace TimeTracker.API.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<TimeEntry> TimeEntries { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<TimeEntry>()
            .HasIndex(t => t.IsDeleted);
    }
}

