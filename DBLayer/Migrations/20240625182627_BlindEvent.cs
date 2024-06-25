using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESOF.WebApp.DBLayer.Migrations
{
    /// <inheritdoc />
    public partial class BlindEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlindEvents",
                columns: table => new
                {
                    BlindEventId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    OrganizerId = table.Column<Guid>(type: "uuid", nullable: false),
                    EventDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlindEvents", x => x.BlindEventId);
                    table.ForeignKey(
                        name: "FK_BlindEvents_Users_OrganizerId",
                        column: x => x.OrganizerId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    ParticipantId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    BlindEventId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.ParticipantId);
                    table.ForeignKey(
                        name: "FK_Participants_BlindEvents_BlindEventId",
                        column: x => x.BlindEventId,
                        principalTable: "BlindEvents",
                        principalColumn: "BlindEventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participants_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Evaluations",
                columns: table => new
                {
                    EvaluationId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    ParticipantId = table.Column<Guid>(type: "uuid", nullable: false),
                    WineId = table.Column<Guid>(type: "uuid", nullable: false),
                    BlindEventId = table.Column<Guid>(type: "uuid", nullable: false),
                    Grade = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluations", x => x.EvaluationId);
                    table.ForeignKey(
                        name: "FK_Evaluations_BlindEvents_BlindEventId",
                        column: x => x.BlindEventId,
                        principalTable: "BlindEvents",
                        principalColumn: "BlindEventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Evaluations_Participants_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "Participants",
                        principalColumn: "ParticipantId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Evaluations_Wines_WineId",
                        column: x => x.WineId,
                        principalTable: "Wines",
                        principalColumn: "WineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParticipantWines",
                columns: table => new
                {
                    ParticipantWineId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    ParticipantId = table.Column<Guid>(type: "uuid", nullable: false),
                    WineId = table.Column<Guid>(type: "uuid", nullable: false),
                    BlindEventId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantWines", x => x.ParticipantWineId);
                    table.ForeignKey(
                        name: "FK_ParticipantWines_BlindEvents_BlindEventId",
                        column: x => x.BlindEventId,
                        principalTable: "BlindEvents",
                        principalColumn: "BlindEventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParticipantWines_Participants_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "Participants",
                        principalColumn: "ParticipantId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParticipantWines_Wines_WineId",
                        column: x => x.WineId,
                        principalTable: "Wines",
                        principalColumn: "WineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlindEvents_OrganizerId",
                table: "BlindEvents",
                column: "OrganizerId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_BlindEventId",
                table: "Evaluations",
                column: "BlindEventId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_ParticipantId",
                table: "Evaluations",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_WineId",
                table: "Evaluations",
                column: "WineId");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_BlindEventId",
                table: "Participants",
                column: "BlindEventId");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_UserId_BlindEventId",
                table: "Participants",
                columns: new[] { "UserId", "BlindEventId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantWines_BlindEventId",
                table: "ParticipantWines",
                column: "BlindEventId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantWines_ParticipantId",
                table: "ParticipantWines",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantWines_WineId_BlindEventId",
                table: "ParticipantWines",
                columns: new[] { "WineId", "BlindEventId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Evaluations");

            migrationBuilder.DropTable(
                name: "ParticipantWines");

            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.DropTable(
                name: "BlindEvents");
        }
    }
}
