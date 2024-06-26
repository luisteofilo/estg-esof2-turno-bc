using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ESOF.WebApp.DBLayer.Migrations
{
    /// <inheritdoc />
    public partial class AlterUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("4c00f8d1-8864-4934-8f29-1b62e56c6ae4"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("5c438660-d9f5-4cea-b692-8c986c33ab37"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("7a262b87-4fb0-4231-820e-4e75bf5fc0c7"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("8c47c63e-ba2f-4ac7-bc2a-a241cad0259c"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("fb3efd21-b190-40b3-ad6c-90310037b369"));

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "Name", "Slug" },
                values: new object[,]
                {
                    { new Guid("235c63fd-b734-46f2-9e99-7afc32f746b1"), "Event2", "event2" },
                    { new Guid("401c9d69-e393-4aab-ada9-4749e32325b5"), "Event5", "event5" },
                    { new Guid("670e8c98-3b34-4da8-b873-4fd591eca753"), "Event4", "event4" },
                    { new Guid("75ef9f1b-6ccb-45ad-8ad3-b03f1a216dec"), "Event1", "event1" },
                    { new Guid("b79756ef-5e01-4a70-ab07-0e916b8397a4"), "Event3", "event3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("235c63fd-b734-46f2-9e99-7afc32f746b1"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("401c9d69-e393-4aab-ada9-4749e32325b5"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("670e8c98-3b34-4da8-b873-4fd591eca753"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("75ef9f1b-6ccb-45ad-8ad3-b03f1a216dec"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b79756ef-5e01-4a70-ab07-0e916b8397a4"));

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Users",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Users",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "Name", "Slug" },
                values: new object[,]
                {
                    { new Guid("4c00f8d1-8864-4934-8f29-1b62e56c6ae4"), "Event2", "event2" },
                    { new Guid("5c438660-d9f5-4cea-b692-8c986c33ab37"), "Event1", "event1" },
                    { new Guid("7a262b87-4fb0-4231-820e-4e75bf5fc0c7"), "Event3", "event3" },
                    { new Guid("8c47c63e-ba2f-4ac7-bc2a-a241cad0259c"), "Event5", "event5" },
                    { new Guid("fb3efd21-b190-40b3-ad6c-90310037b369"), "Event4", "event4" }
                });
        }
    }
}
