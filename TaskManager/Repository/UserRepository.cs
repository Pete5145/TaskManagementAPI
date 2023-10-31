using Microsoft.EntityFrameworkCore;
using TaskManager.Contracts;
using TaskManager.Data;
using TaskManager.Models;

namespace TaskManager.Repository;

public class UserRepository: GenericRepository<User>, IUserRepository
{
    private readonly TaskManagerDbContext _context;

    public UserRepository(TaskManagerDbContext context) : base(context)
    {
        this._context = context;
    }

    public async Task<User> GetUserDetails(int id)
    {
       return await _context.Users.Include(q => q.Tasks).Include(q => q.Notifications).FirstOrDefaultAsync(q => q.Id == id);
    }
}
