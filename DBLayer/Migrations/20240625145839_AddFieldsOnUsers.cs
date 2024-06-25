using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ESOF.WebApp.DBLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldsOnUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("5b50f84e-0cde-43e8-8048-8efdbff24818"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("767a6963-6e91-469e-a6d9-2cac0d5bf145"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("81ec015d-0d73-4f45-a098-01f5eb3cd084"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("878d8256-50bd-4870-8f52-3e490537bc1c"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("dac5b230-b134-4cd9-a73a-b22a73f76e6b"));

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthdayDate",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "Address",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BirthdayDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "Name", "Slug" },
                values: new object[,]
                {
                    { new Guid("5b50f84e-0cde-43e8-8048-8efdbff24818"), "Event1", "event1" },
                    { new Guid("767a6963-6e91-469e-a6d9-2cac0d5bf145"), "Event4", "event4" },
                    { new Guid("81ec015d-0d73-4f45-a098-01f5eb3cd084"), "Event3", "event3" },
                    { new Guid("878d8256-50bd-4870-8f52-3e490537bc1c"), "Event2", "event2" },
                    { new Guid("dac5b230-b134-4cd9-a73a-b22a73f76e6b"), "Event5", "event5" }
                });
        }
    }
}
