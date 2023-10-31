using Microsoft.Build.Framework;

namespace TaskManager.Dtos.Project;

public class BaseProjectDto
{
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Description { get; set; }
}
