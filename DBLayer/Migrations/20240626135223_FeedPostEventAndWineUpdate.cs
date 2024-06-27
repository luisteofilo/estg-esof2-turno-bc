using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ESOF.WebApp.DBLayer.Migrations
{
    /// <inheritdoc />
    public partial class FeedPostEventAndWineUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Events_EventId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Wines_WineId",
                table: "Posts");

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("12960141-151c-4953-922c-bc7fd056ac92"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("6b79280e-e33e-42b7-aa62-1da7ca4bf609"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("aa28ce4b-00d5-495f-bae9-307f8481d6a0"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("e15b414b-40cb-4f13-a7fe-3019e28b1924"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("e1eabb7c-982f-455e-8662-f1cb22e8baf6"));

            migrationBuilder.RenameColumn(
                name: "WineId",
                table: "Posts",
                newName: "PostWineId");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "Posts",
                newName: "PostEventId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_WineId",
                table: "Posts",
                newName: "IX_Posts_PostWineId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_EventId",
                table: "Posts",
                newName: "IX_Posts_PostEventId");

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "Name", "Slug" },
                values: new object[,]
                {
                    { new Guid("467d1848-63c7-4830-b8c4-2d2a92f807ae"), "Event1", "event1" },
                    { new Guid("6156d17f-bf49-4217-9b51-42ef1307250e"), "Event4", "event4" },
                    { new Guid("b0bef1f5-43aa-47aa-9a2e-f4a320b8f77d"), "Event3", "event3" },
                    { new Guid("c78bc453-5bcf-431e-acc6-5247c8744c2f"), "Event5", "event5" },
                    { new Guid("dcdcec57-a682-4a4c-abaf-f55f00a3cfbf"), "Event2", "event2" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Events_PostEventId",
                table: "Posts",
                column: "PostEventId",
                principalTable: "Events",
                principalColumn: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Wines_PostWineId",
                table: "Posts",
                column: "PostWineId",
                principalTable: "Wines",
                principalColumn: "WineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Events_PostEventId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Wines_PostWineId",
                table: "Posts");

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("467d1848-63c7-4830-b8c4-2d2a92f807ae"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("6156d17f-bf49-4217-9b51-42ef1307250e"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b0bef1f5-43aa-47aa-9a2e-f4a320b8f77d"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("c78bc453-5bcf-431e-acc6-5247c8744c2f"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("dcdcec57-a682-4a4c-abaf-f55f00a3cfbf"));

            migrationBuilder.RenameColumn(
                name: "PostWineId",
                table: "Posts",
                newName: "WineId");

            migrationBuilder.RenameColumn(
                name: "PostEventId",
                table: "Posts",
                newName: "EventId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_PostWineId",
                table: "Posts",
                newName: "IX_Posts_WineId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_PostEventId",
                table: "Posts",
                newName: "IX_Posts_EventId");

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "Name", "Slug" },
                values: new object[,]
                {
                    { new Guid("12960141-151c-4953-922c-bc7fd056ac92"), "Event3", "event3" },
                    { new Guid("6b79280e-e33e-42b7-aa62-1da7ca4bf609"), "Event1", "event1" },
                    { new Guid("aa28ce4b-00d5-495f-bae9-307f8481d6a0"), "Event5", "event5" },
                    { new Guid("e15b414b-40cb-4f13-a7fe-3019e28b1924"), "Event4", "event4" },
                    { new Guid("e1eabb7c-982f-455e-8662-f1cb22e8baf6"), "Event2", "event2" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Events_EventId",
                table: "Posts",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Wines_WineId",
                table: "Posts",
                column: "WineId",
                principalTable: "Wines",
                principalColumn: "WineId");
        }
    }
}
