using Microsoft.EntityFrameworkCore;
using TaskManager.Contracts;
using TaskManager.Data;
using TaskManager.Models;

namespace TaskManager.Repository;

public class TaskRepository : GenericRepository<Tasks>, ITaskRepository
{
    private readonly TaskManagerDbContext _context;

    public TaskRepository(TaskManagerDbContext context) : base(context)
    {
        this._context = context;
    }
     
    public async Task<List<Tasks>> GetTasksBasedOnCurrentWeek()
    {

        DateTime currentDate = DateTime.Now;
        DateTime startOfWeek = currentDate.Date.AddDays(-(int)currentDate.DayOfWeek);
        DateTime endOfWeek = startOfWeek.AddDays(7).AddSeconds(-1);

        var tasksInCurrentWeek = await _context.Tasks
            .Where(t => t.DueDate >= startOfWeek && t.DueDate <= endOfWeek)
            .ToListAsync();

        if (tasksInCurrentWeek == null)
        {
            return null;
        }
        return tasksInCurrentWeek;
    }

    public async Task<List<Tasks>> GetTasksBasedOnStatus(string status)
    { 
        switch (status)
        {
            case "pending":
               return await _context.Tasks.Where(q => q.Status == status).ToListAsync();
            case "in-progress":
               return await _context.Tasks.Where(q => q.Status == status).ToListAsync();
            case "completed":
                return await _context.Tasks.Where(q => q.Status == status).ToListAsync();
        } 
        return null;
    }
}
