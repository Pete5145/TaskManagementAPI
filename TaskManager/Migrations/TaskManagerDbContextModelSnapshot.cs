﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskManager.Data;

#nullable disable

namespace TaskManager.Migrations
{
    [DbContext(typeof(TaskManagerDbContext))]
    partial class TaskManagerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TaskManager.Models.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Notifications");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsRead = true,
                            Message = "Your task is due soon",
                            TimeStamp = new DateTime(2023, 11, 1, 16, 19, 17, 411, DateTimeKind.Local).AddTicks(7246),
                            Type = "Due Date Reminder!",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            IsRead = false,
                            Message = "Task status has changed to 'In-Progress'.",
                            TimeStamp = new DateTime(2023, 10, 30, 16, 19, 17, 411, DateTimeKind.Local).AddTicks(7261),
                            Type = "Status Update",
                            UserId = 2
                        });
                });

            modelBuilder.Entity("TaskManager.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "A social media platform for messaging, blogging, and tweeting.",
                            Name = "X"
                        },
                        new
                        {
                            Id = 2,
                            Description = "A cooking website for world class chefs and bakers.",
                            Name = "Hottery"
                        },
                        new
                        {
                            Id = 3,
                            Description = "A financial banking app.",
                            Name = "Tenet"
                        });
                });

            modelBuilder.Entity("TaskManager.Models.Tasks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Priority")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("UserId");

                    b.ToTable("Tasks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Fix a bug on the main codebase",
                            DueDate = new DateTime(2023, 10, 31, 16, 19, 17, 411, DateTimeKind.Local).AddTicks(5526),
                            Priority = "high",
                            ProjectId = 2,
                            Status = "completed",
                            Title = "Bug Fix",
                            UserId = 3
                        },
                        new
                        {
                            Id = 2,
                            Description = "Refactor the code on SOLID principles.",
                            DueDate = new DateTime(2023, 10, 31, 16, 19, 17, 411, DateTimeKind.Local).AddTicks(5586),
                            Priority = "medium",
                            ProjectId = 1,
                            Status = "pending",
                            Title = "Refactor Codebase",
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            Description = "Commit and push the repositories to Github",
                            DueDate = new DateTime(2023, 10, 31, 16, 19, 17, 411, DateTimeKind.Local).AddTicks(5593),
                            Priority = "low",
                            ProjectId = 3,
                            Status = "in-progress",
                            Title = "Commit and Push Code",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("TaskManager.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "peterhunter6@gmail.com",
                            Name = "Peter Hunter"
                        },
                        new
                        {
                            Id = 2,
                            Email = "davidblaine34@gmail.com",
                            Name = "David Blaine"
                        },
                        new
                        {
                            Id = 3,
                            Email = "jamesstuart92@gmail.com",
                            Name = "James Stuart"
                        });
                });

            modelBuilder.Entity("TaskManager.Models.Notification", b =>
                {
                    b.HasOne("TaskManager.Models.User", "User")
                        .WithMany("Notifications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TaskManager.Models.Tasks", b =>
                {
                    b.HasOne("TaskManager.Models.Project", "Project")
                        .WithMany("Tasks")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaskManager.Models.User", "User")
                        .WithMany("Tasks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TaskManager.Models.Project", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("TaskManager.Models.User", b =>
                {
                    b.Navigation("Notifications");

                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}