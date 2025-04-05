namespace TimeTracker.Shared.Dtos.Project;
public record struct ProjectCreateRequest
(
    string Name
)
{
    // Mark 'Name' as required
    public required string Name { get; init; } = Name;
}