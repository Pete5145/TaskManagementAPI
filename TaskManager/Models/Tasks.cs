using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Models
{
    public class Tasks: BaseModel
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public string? Priority { get; set; }
        public string? Status { get; set; }

        [ForeignKey(nameof(ProjectId))]
        public int ProjectId { get; set; }
        public Project? Project { get; set; }
        
        [ForeignKey(nameof(UserId))]
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
