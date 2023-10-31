namespace TaskManager.Dtos.Notification
{
    public class BaseNotificationDto
    {
        public string? Type { get; set; }
        public string? Message { get; set; }
        public bool IsRead { get; set; }
        public DateTime TimeStamp { get; set; }
        public int UserId { get; set; }
    }
}
