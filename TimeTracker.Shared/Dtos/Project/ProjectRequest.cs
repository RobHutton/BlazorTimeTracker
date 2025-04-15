using System.ComponentModel.DataAnnotations;

namespace TimeTracker.Shared.Dtos.Project;

public class ProjectRequest
{
    [Required(ErrorMessage = "Project name is required.")]
    [MinLength(5, ErrorMessage = "Project name must be at least 5 characters long.")]
    [MaxLength(100, ErrorMessage = "Project name cannot exceed 100 characters.")]
    public string Name { get; set; } = string.Empty;
}
