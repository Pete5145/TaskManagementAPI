using TaskManager.Models;

namespace TaskManager.Contracts;
public interface IUserRepository: IGenericRepository<User>
{
    Task<User> GetUserDetails(int id);
}
