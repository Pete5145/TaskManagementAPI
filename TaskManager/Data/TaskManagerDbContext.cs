using Microsoft.EntityFrameworkCore;
using TaskManager.Models;

namespace TaskManager.Data;

public class TaskManagerDbContext: DbContext
{
    public TaskManagerDbContext(DbContextOptions options): base(options)
    {
        
    }

    public DbSet<Tasks> Tasks { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Notification> Notifications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Tasks>().HasData(
            new Tasks
            {
                Id = 1,
                Description = "Fix a bug on the main codebase",
                Title = "Bug Fix",
                Status = "completed",
                DueDate = DateTime.Now.AddDays(1),
                Priority = "high",
                UserId = 3,
                ProjectId = 2,
            },
            new Tasks
            {
                Id = 2,
                Description = "Refactor the code on SOLID principles.",
                Title = "Refactor Codebase",
                Status = "pending",
                DueDate = DateTime.Now.AddDays(1),
                Priority = "medium",
                UserId = 2,
                ProjectId = 1,
            },
            new Tasks
            {
                Id = 3,
                Description = "Commit and push the repositories to Github",
                Title = "Commit and Push Code",
                Status = "in-progress",
                DueDate = DateTime.Now.AddDays(1),
                Priority = "low",
                UserId = 1,
                ProjectId = 3,
            }
        );

        modelBuilder.Entity<Project>().HasData(
            new Project
            {
                Id = 1,
                Name = "X",
                Description = "A social media platform for messaging, blogging, and tweeting."
            },
            new Project
            {
                Id = 2,
                Name = "Hottery",
                Description = "A cooking website for world class chefs and bakers."
            },  
            new Project
            {
                Id = 3,
                Name = "Tenet",
                Description = "A financial banking app."
            } 
        );

        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                Name = "Peter Hunter",
                Email = "peterhunter6@gmail.com"
            }, 
            new User
            {
                Id = 2,
                Name = "David Blaine",
                Email = "davidblaine34@gmail.com"
            }, 
            new User
            {
                Id = 3,
                Name = "James Stuart",
                Email = "jamesstuart92@gmail.com",
            }
        );

        modelBuilder.Entity<Notification>().HasData(
             new Notification
             {
                 Id = 1,
                 Type = "Due Date Reminder!",
                 Message = "Your task is due soon",
                 UserId = 1,
                 TimeStamp = DateTime.Now.AddDays(2),
                 IsRead = true
             },
             new Notification
             {
                 Id = 2,
                 Message = "Task status has changed to 'In-Progress'.",
                 Type = "Status Update",
                 UserId = 2,
                 TimeStamp = DateTime.Now,
                 IsRead = false
             }
        ); ;
    }
}


