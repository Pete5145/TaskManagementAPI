using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Models
{
    public class Notification: BaseModel
    {
        public string? Type { get; set; }
        public string? Message { get; set; }
        public DateTime TimeStamp { get; set; } 
        public bool IsRead { get; set; }

        [ForeignKey(nameof(UserId))]
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}