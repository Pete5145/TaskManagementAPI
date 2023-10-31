using TaskManager.Contracts;
using TaskManager.Data;
using TaskManager.Models;

namespace TaskManager.Repository
{
    public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
    {
        private readonly TaskManagerDbContext _context;

        public NotificationRepository(TaskManagerDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<Notification> MarkNotificationAsRead(int id)
        {
            var notification = await _context.Notifications.FindAsync(id);
            if (notification == null)
            {
                return null;
            }
 
            notification.IsRead = true;
            await _context.SaveChangesAsync();

            return notification;
        }

        public async Task<Notification> MarkNotificationAsUnRead(int id)
        {
            var notification = await _context.Notifications.FindAsync(id);

            if (notification == null)
            {
                return null;
            }

            notification.IsRead = false;
            await _context.SaveChangesAsync();

            return notification;
        } 
    }
}