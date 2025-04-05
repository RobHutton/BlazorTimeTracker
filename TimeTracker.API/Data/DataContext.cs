namespace TimeTracker.API.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<TimeEntry> TimeEntries { get; set; }
    public DbSet<Project> Projects { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Create Index
        modelBuilder.Entity<TimeEntry>()
            .HasIndex(t => t.IsDeleted);
        modelBuilder.Entity<TimeEntry>()
            .HasIndex(t => t.ProjectId);
        modelBuilder.Entity<Project>()
            .HasIndex(t => t.IsDeleted);

        // Define the One-to-Many Relationship
        modelBuilder.Entity<TimeEntry>()
            .HasOne(t => t.Project)  // A TimeEntry has one Project
            .WithMany(p => p.TimeEntries) // A Project has many TimeEntries
            .HasForeignKey(t => t.ProjectId) // The foreign key in TimeEntry
            .OnDelete(DeleteBehavior.Cascade); // Deleting a Project deletes its TimeEntries (optional)
    }
}

