using TaskManager.Dtos.Notification;
using TaskManager.Dtos.Tasks;
using TaskManager.Models;

namespace TaskManager.Dtos.User
{
    public class GetUserDto: BaseUserDto
    {
        public int Id { get; set; }  
        public virtual IList<GetTaskDto>? Tasks { get; set; }
        public virtual IList<GetNotificationDto>? Notifications { get; set; }
    }
}
