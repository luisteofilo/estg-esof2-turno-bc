using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ESOF.WebApp.DBLayer.Migrations
{
    /// <inheritdoc />
    public partial class TasteEvaluations_Event : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EventId",
                table: "TasteQuestions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "EventId",
                table: "TasteEvaluations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_TasteQuestions_EventId",
                table: "TasteQuestions",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_TasteEvaluations_EventId",
                table: "TasteEvaluations",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_TasteEvaluations_Events_EventId",
                table: "TasteEvaluations",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TasteQuestions_Events_EventId",
                table: "TasteQuestions",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TasteEvaluations_Events_EventId",
                table: "TasteEvaluations");

            migrationBuilder.DropForeignKey(
                name: "FK_TasteQuestions_Events_EventId",
                table: "TasteQuestions");

            migrationBuilder.DropIndex(
                name: "IX_TasteQuestions_EventId",
                table: "TasteQuestions");

            migrationBuilder.DropIndex(
                name: "IX_TasteEvaluations_EventId",
                table: "TasteEvaluations");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "TasteQuestions");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "TasteEvaluations");
        }
    }
}
