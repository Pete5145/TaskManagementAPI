using TaskManager.Models;

namespace TaskManager.Contracts;

public interface ITaskRepository: IGenericRepository<Tasks>
{
    Task<List<Tasks>> GetTasksBasedOnStatus(string status);
    Task<List<Tasks>> GetTasksBasedOnCurrentWeek();
}
