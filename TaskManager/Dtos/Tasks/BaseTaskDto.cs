﻿namespace TaskManager.Dtos.Tasks
{
    public class BaseTaskDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public string? Priority { get; set; }
        public string? Status { get; set; }
        public int ProjectId { get; set; } 
        public int UserId { get; set; }
    }
}
