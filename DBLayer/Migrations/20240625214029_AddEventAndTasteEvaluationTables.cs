using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ESOF.WebApp.DBLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddEventAndTasteEvaluationTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Slug = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                });

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

            migrationBuilder.CreateTable(
                name: "TasteEvaluations",
                columns: table => new
                {
                    TasteEvaluationId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    WineId = table.Column<Guid>(type: "uuid", nullable: false),
                    EventId = table.Column<Guid>(type: "uuid", nullable: false),
                    WineScore = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TasteEvaluations", x => x.TasteEvaluationId);
                    table.ForeignKey(
                        name: "FK_TasteEvaluations_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TasteEvaluations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TasteEvaluations_Wines_WineId",
                        column: x => x.WineId,
                        principalTable: "Wines",
                        principalColumn: "WineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "Name", "Slug" },
                values: new object[,]
                {
                    { new Guid("0953701b-dbde-4d52-8eb6-88c2c317516e"), "Event2", "event2" },
                    { new Guid("0c86cf2b-8d9f-453d-bc29-c628a38b0ea9"), "Event5", "event5" },
                    { new Guid("60db056b-f39e-4943-89ab-0b2bb8a93a8f"), "Event3", "event3" },
                    { new Guid("99611bb2-580a-4192-9cf2-b70a9aa4227f"), "Event1", "event1" },
                    { new Guid("bcae7da7-671c-4051-bb26-6fc3eb5d0b95"), "Event4", "event4" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventParticipants_EventId",
                table: "EventParticipants",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventParticipants_UserId",
                table: "EventParticipants",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TasteEvaluations_EventId",
                table: "TasteEvaluations",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_TasteEvaluations_UserId",
                table: "TasteEvaluations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TasteEvaluations_WineId",
                table: "TasteEvaluations",
                column: "WineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventParticipants");

            migrationBuilder.DropTable(
                name: "TasteEvaluations");

            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
