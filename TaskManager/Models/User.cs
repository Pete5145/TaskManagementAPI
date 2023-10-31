namespace TaskManager.Models
{
    public class User: BaseModel
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public virtual IList<Tasks>? Tasks { get; set; }
        public virtual IList<Notification>? Notifications { get; set; }
    }
}