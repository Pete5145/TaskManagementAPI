using Microsoft.Build.Framework;
namespace TaskManager.Dtos.User;

public abstract class BaseUserDto
{
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Email { get; set; }
}