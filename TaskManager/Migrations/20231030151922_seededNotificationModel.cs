using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskManager.Migrations
{
    /// <inheritdoc />
    public partial class seededNotificationModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRead",
                table: "Notifications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "IsRead", "Message", "TimeStamp", "Type", "UserId" },
                values: new object[,]
                {
                    { 1, true, "Your task is due soon", new DateTime(2023, 11, 1, 16, 19, 17, 411, DateTimeKind.Local).AddTicks(7246), "Due Date Reminder!", 1 },
                    { 2, false, "Task status has changed to 'In-Progress'.", new DateTime(2023, 10, 30, 16, 19, 17, 411, DateTimeKind.Local).AddTicks(7261), "Status Update", 2 }
                });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "DueDate",
                value: new DateTime(2023, 10, 31, 16, 19, 17, 411, DateTimeKind.Local).AddTicks(5526));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "DueDate",
                value: new DateTime(2023, 10, 31, 16, 19, 17, 411, DateTimeKind.Local).AddTicks(5586));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                column: "DueDate",
                value: new DateTime(2023, 10, 31, 16, 19, 17, 411, DateTimeKind.Local).AddTicks(5593));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "IsRead",
                table: "Notifications");

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "DueDate",
                value: new DateTime(2023, 10, 27, 10, 50, 46, 655, DateTimeKind.Local).AddTicks(9655));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "DueDate",
                value: new DateTime(2023, 11, 1, 10, 50, 46, 655, DateTimeKind.Local).AddTicks(9725));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                column: "DueDate",
                value: new DateTime(2023, 10, 31, 10, 50, 46, 655, DateTimeKind.Local).AddTicks(9733));
        }
    }
}
