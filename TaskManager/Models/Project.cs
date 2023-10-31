namespace TaskManager.Models
{
    public class Project: BaseModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public virtual IList<Tasks>? Tasks { get; set; }
    }
}
