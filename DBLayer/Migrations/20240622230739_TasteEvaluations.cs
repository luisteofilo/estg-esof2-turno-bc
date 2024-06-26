using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESOF.WebApp.DBLayer.Migrations
{
    /// <inheritdoc />
    public partial class TasteEvaluations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TasteEvaluations",
                columns: table => new
                {
                    TasteEvaluationId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    WineId = table.Column<Guid>(type: "uuid", nullable: false),
                    WineScore = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TasteEvaluations", x => x.TasteEvaluationId);
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

            migrationBuilder.CreateTable(
                name: "TasteQuestionTypes",
                columns: table => new
                {
                    TasteQuestionTypeId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TasteQuestionTypes", x => x.TasteQuestionTypeId);
                });

            migrationBuilder.CreateTable(
                name: "TasteQuestions",
                columns: table => new
                {
                    TasteQuestionId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Question = table.Column<string>(type: "text", nullable: false),
                    TasteQuestionTypeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TasteQuestions", x => x.TasteQuestionId);
                    table.ForeignKey(
                        name: "FK_TasteQuestions_TasteQuestionTypes_TasteQuestionTypeId",
                        column: x => x.TasteQuestionTypeId,
                        principalTable: "TasteQuestionTypes",
                        principalColumn: "TasteQuestionTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TasteEvaluationQuestions",
                columns: table => new
                {
                    TasteEvaluationQuestionId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    TasteEvaluationId = table.Column<Guid>(type: "uuid", nullable: false),
                    TasteQuestionId = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TasteEvaluationQuestions", x => x.TasteEvaluationQuestionId);
                    table.ForeignKey(
                        name: "FK_TasteEvaluationQuestions_TasteEvaluations_TasteEvaluationId",
                        column: x => x.TasteEvaluationId,
                        principalTable: "TasteEvaluations",
                        principalColumn: "TasteEvaluationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TasteEvaluationQuestions_TasteQuestions_TasteQuestionId",
                        column: x => x.TasteQuestionId,
                        principalTable: "TasteQuestions",
                        principalColumn: "TasteQuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TasteEvaluationQuestions_TasteEvaluationId",
                table: "TasteEvaluationQuestions",
                column: "TasteEvaluationId");

            migrationBuilder.CreateIndex(
                name: "IX_TasteEvaluationQuestions_TasteQuestionId",
                table: "TasteEvaluationQuestions",
                column: "TasteQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_TasteEvaluations_UserId",
                table: "TasteEvaluations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TasteEvaluations_WineId",
                table: "TasteEvaluations",
                column: "WineId");

            migrationBuilder.CreateIndex(
                name: "IX_TasteQuestions_TasteQuestionTypeId",
                table: "TasteQuestions",
                column: "TasteQuestionTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TasteEvaluationQuestions");

            migrationBuilder.DropTable(
                name: "TasteEvaluations");

            migrationBuilder.DropTable(
                name: "TasteQuestions");

            migrationBuilder.DropTable(
                name: "TasteQuestionTypes");
        }
    }
}
