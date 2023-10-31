using Microsoft.EntityFrameworkCore;
using TaskManager.Contracts;
using TaskManager.Data;
using TaskManager.Models;

namespace TaskManager.Repository;

public class ProjectRepository: GenericRepository<Project>, IProjectRepository
{
    private readonly TaskManagerDbContext _context;

    public ProjectRepository(TaskManagerDbContext context) : base(context)
    {
        this._context = context;
    }

    public async Task<Project> AssignTaskToProject(int projectId, int taskId)
    {
        var project = await _context.Projects.Include(q => q.Tasks).FirstOrDefaultAsync(q => q.Id == projectId);
        var task = await _context.Tasks.FindAsync(taskId);

        if (project == null || task == null)
        { 
            return null;
        }

        project.Tasks?.Add(task);
        await _context.SaveChangesAsync();

        return project;
    } 

    public async Task<Project> GetProjectDetails(int id)
    {
        return await _context.Projects.Include(q => q.Tasks).FirstOrDefaultAsync(q => q.Id == id);
    }

    public async Task<Project> RemoveTaskFromProject(int projectId, int taskId)
    {
        var project = await _context.Projects.Include(q => q.Tasks).FirstOrDefaultAsync(q => q.Id == projectId);
        var task = await _context.Tasks.FindAsync(taskId);

        if (project == null || task == null)
        {
            return null;
        }

        project.Tasks?.Remove(task);
        await _context.SaveChangesAsync();

        return project;
    }
}
