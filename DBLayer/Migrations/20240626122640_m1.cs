using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ESOF.WebApp.DBLayer.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
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

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "Name", "Slug" },
                values: new object[,]
                {
                    { new Guid("147e30bd-66a9-4cee-8a76-25cd3277d8b9"), "Event2", "event2" },
                    { new Guid("1aecc6df-a69d-4f26-901e-1dd95bd79b16"), "Event1", "event1" },
                    { new Guid("7437e2e7-9e45-41a8-836b-207d24dbf766"), "Event5", "event5" },
                    { new Guid("8d0ef506-181b-4f9f-b168-accb67ea4020"), "Event4", "event4" },
                    { new Guid("c2677a41-a1b2-412d-8672-5db26a586a43"), "Event3", "event3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("147e30bd-66a9-4cee-8a76-25cd3277d8b9"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("1aecc6df-a69d-4f26-901e-1dd95bd79b16"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("7437e2e7-9e45-41a8-836b-207d24dbf766"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("8d0ef506-181b-4f9f-b168-accb67ea4020"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("c2677a41-a1b2-412d-8672-5db26a586a43"));

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
