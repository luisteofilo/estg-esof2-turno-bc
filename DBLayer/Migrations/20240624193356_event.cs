using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ESOF.WebApp.DBLayer.Migrations
{
    /// <inheritdoc />
    public partial class @event : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WineCategoryLinks_Wines_WineCategoryLinkId",
                table: "WineCategoryLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_WineGrapeTypeLinks_GrapeType_GrapeTypeId",
                table: "WineGrapeTypeLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_WineGrapeTypeLinks_Wines_WineGrapeTypeLinkId",
                table: "WineGrapeTypeLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_Wines_Events_EventId",
                table: "Wines");

            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WineCategoryLinks",
                table: "WineCategoryLinks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GrapeType",
                table: "GrapeType");

            migrationBuilder.RenameTable(
                name: "WineCategoryLinks",
                newName: "WineCategoryLink");

            migrationBuilder.RenameTable(
                name: "GrapeType",
                newName: "GrapeTypes");

            migrationBuilder.AlterColumn<Guid>(
                name: "WineGrapeTypeLinkId",
                table: "WineGrapeTypeLinks",
                type: "uuid",
                nullable: false,
                defaultValueSql: "gen_random_uuid()",
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Events",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Events",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<Guid>(
                name: "GrapeTypeId",
                table: "GrapeTypes",
                type: "uuid",
                nullable: false,
                defaultValueSql: "gen_random_uuid()",
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WineCategoryLink",
                table: "WineCategoryLink",
                column: "WineCategoryLinkId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GrapeTypes",
                table: "GrapeTypes",
                column: "GrapeTypeId");

            migrationBuilder.CreateTable(
                name: "EventParticipants",
                columns: table => new
                {
                    EventParticipantId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    EventId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventParticipants", x => x.EventParticipantId);
                    table.ForeignKey(
                        name: "FK_EventParticipants_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventParticipants_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "BlindTasting", "Date", "Name", "Slug" },
                values: new object[,]
                {
                    { new Guid("3956f3a7-cef6-42ac-9565-96fde9349ba2"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event3", "event3" },
                    { new Guid("3cf47f51-0df2-4d36-8b85-8c6a35e0acb3"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event2", "event2" },
                    { new Guid("b6300006-a07e-43de-a0d1-627ea7f21cb8"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event5", "event5" },
                    { new Guid("bf77fb6e-3069-4f86-bb6a-d549c1ec0969"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event4", "event4" },
                    { new Guid("c43482fc-c9b9-4106-9497-cec7ddea1745"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event1", "event1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_WineGrapeTypeLinks_WineId",
                table: "WineGrapeTypeLinks",
                column: "WineId");

            migrationBuilder.CreateIndex(
                name: "IX_EventParticipants_EventId",
                table: "EventParticipants",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventParticipants_UserId",
                table: "EventParticipants",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WineCategoryLink_Wines_WineCategoryLinkId",
                table: "WineCategoryLink",
                column: "WineCategoryLinkId",
                principalTable: "Wines",
                principalColumn: "WineId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WineGrapeTypeLinks_GrapeTypes_GrapeTypeId",
                table: "WineGrapeTypeLinks",
                column: "GrapeTypeId",
                principalTable: "GrapeTypes",
                principalColumn: "GrapeTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WineGrapeTypeLinks_Wines_WineId",
                table: "WineGrapeTypeLinks",
                column: "WineId",
                principalTable: "Wines",
                principalColumn: "WineId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wines_Events_EventId",
                table: "Wines",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WineCategoryLink_Wines_WineCategoryLinkId",
                table: "WineCategoryLink");

            migrationBuilder.DropForeignKey(
                name: "FK_WineGrapeTypeLinks_GrapeTypes_GrapeTypeId",
                table: "WineGrapeTypeLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_WineGrapeTypeLinks_Wines_WineId",
                table: "WineGrapeTypeLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_Wines_Events_EventId",
                table: "Wines");

            migrationBuilder.DropTable(
                name: "EventParticipants");

            migrationBuilder.DropIndex(
                name: "IX_WineGrapeTypeLinks_WineId",
                table: "WineGrapeTypeLinks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WineCategoryLink",
                table: "WineCategoryLink");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GrapeTypes",
                table: "GrapeTypes");

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3956f3a7-cef6-42ac-9565-96fde9349ba2"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3cf47f51-0df2-4d36-8b85-8c6a35e0acb3"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b6300006-a07e-43de-a0d1-627ea7f21cb8"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("bf77fb6e-3069-4f86-bb6a-d549c1ec0969"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("c43482fc-c9b9-4106-9497-cec7ddea1745"));

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Events");

            migrationBuilder.RenameTable(
                name: "WineCategoryLink",
                newName: "WineCategoryLinks");

            migrationBuilder.RenameTable(
                name: "GrapeTypes",
                newName: "GrapeType");

            migrationBuilder.AlterColumn<Guid>(
                name: "WineGrapeTypeLinkId",
                table: "WineGrapeTypeLinks",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValueSql: "gen_random_uuid()");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Events",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<Guid>(
                name: "GrapeTypeId",
                table: "GrapeType",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValueSql: "gen_random_uuid()");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WineCategoryLinks",
                table: "WineCategoryLinks",
                column: "WineCategoryLinkId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GrapeType",
                table: "GrapeType",
                column: "GrapeTypeId");

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    ParticipantId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Email = table.Column<string>(type: "text", nullable: false),
                    EventId = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.ParticipantId);
                    table.ForeignKey(
                        name: "FK_Participants_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Participants_Email",
                table: "Participants",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Participants_EventId",
                table: "Participants",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_WineCategoryLinks_Wines_WineCategoryLinkId",
                table: "WineCategoryLinks",
                column: "WineCategoryLinkId",
                principalTable: "Wines",
                principalColumn: "WineId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WineGrapeTypeLinks_GrapeType_GrapeTypeId",
                table: "WineGrapeTypeLinks",
                column: "GrapeTypeId",
                principalTable: "GrapeType",
                principalColumn: "GrapeTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WineGrapeTypeLinks_Wines_WineGrapeTypeLinkId",
                table: "WineGrapeTypeLinks",
                column: "WineGrapeTypeLinkId",
                principalTable: "Wines",
                principalColumn: "WineId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wines_Events_EventId",
                table: "Wines",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
