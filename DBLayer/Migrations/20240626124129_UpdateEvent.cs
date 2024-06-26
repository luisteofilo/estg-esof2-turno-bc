using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ESOF.WebApp.DBLayer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
       

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "BlindTasting", "Description", "Name", "Slug", "WineType" },
                values: new object[,]
                {
                    { new Guid("2159ecd2-086f-44bb-a532-699b80aae184"), true, "Description for Event 3", "Event3", "event3", "Sparkling" },
                    { new Guid("2f746ea3-b15b-4d76-af71-50f5ee706412"), false, "Description for Event 5", "Event5", "event5", "Desset" },
                    { new Guid("598cdd9b-4771-4cc4-ba60-3f015d9921d9"), true, "Description for Event 2", "Event2", "event2", "White" },
                    { new Guid("b5acfc13-3092-453b-89f4-596de2b1b354"), false, "Description for Event 1", "Event1", "event1", "Red" },
                    { new Guid("f69e618a-9056-4d9b-86f1-4eebffcc3239"), false, "Description for Event 4", "Event4", "event4", "Rose" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("2159ecd2-086f-44bb-a532-699b80aae184"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("2f746ea3-b15b-4d76-af71-50f5ee706412"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("598cdd9b-4771-4cc4-ba60-3f015d9921d9"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b5acfc13-3092-453b-89f4-596de2b1b354"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("f69e618a-9056-4d9b-86f1-4eebffcc3239"));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Events",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EventDate",
                table: "Events",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
