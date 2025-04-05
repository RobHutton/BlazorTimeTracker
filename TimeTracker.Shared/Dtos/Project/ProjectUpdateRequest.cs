namespace TimeTracker.Shared.Dtos.Project;
public record struct ProjectUpdateRequest
(
    string Name
)
{
    // Mark 'Name' as required
    public required string Name { get; init; } = Name;
}