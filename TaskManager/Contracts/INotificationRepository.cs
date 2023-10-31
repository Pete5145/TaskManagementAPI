using TaskManager.Models;

namespace TaskManager.Contracts
{
    public interface INotificationRepository: IGenericRepository<Notification>
    {
        Task<Notification> MarkNotificationAsRead(int id);
        Task<Notification> MarkNotificationAsUnRead(int id);
    }
}
