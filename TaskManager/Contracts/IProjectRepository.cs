using TaskManager.Models;

namespace TaskManager.Contracts;

public interface IProjectRepository: IGenericRepository<Project>
{
    Task<Project> GetProjectDetails(int id);
    Task<Project> AssignTaskToProject(int projectId, int taskId);
    Task<Project> RemoveTaskFromProject(int projectId, int taskId);

}
