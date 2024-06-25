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
                name: "Brands",
                columns: table => new
                {
                    BrandId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    BlindTasting = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                });

            migrationBuilder.CreateTable(
                name: "GrapeTypes",
                columns: table => new
                {
                    GrapeTypeId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrapeTypes", x => x.GrapeTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    RegionId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.RegionId);
                });

            migrationBuilder.CreateTable(
                name: "TasteQuestionsTypes",
                columns: table => new
                {
                    TasteQuestionsTypeId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TasteQuestionsTypes", x => x.TasteQuestionsTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    ParticipantId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    EventId = table.Column<Guid>(type: "uuid", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Wines",
                columns: table => new
                {
                    WineId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    BrandId = table.Column<Guid>(type: "uuid", nullable: false),
                    RegionId = table.Column<Guid>(type: "uuid", nullable: false),
                    label = table.Column<string>(type: "text", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    category = table.Column<string>(type: "text", nullable: true),
                    LabelDesignation = table.Column<string>(type: "text", nullable: true),
                    Alcohol = table.Column<double>(type: "double precision", nullable: true),
                    MinimumPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    MaximumPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    EventId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wines", x => x.WineId);
                    table.ForeignKey(
                        name: "FK_Wines_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId");
                    table.ForeignKey(
                        name: "FK_Wines_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Wines_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "RegionId");
                });

            migrationBuilder.CreateTable(
                name: "TasteQuestions",
                columns: table => new
                {
                    TasteQuestionId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Questions = table.Column<string>(type: "text", nullable: false),
                    QuestionTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    EventId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TasteQuestions", x => x.TasteQuestionId);
                    table.ForeignKey(
                        name: "FK_TasteQuestions_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TasteQuestions_TasteQuestionsTypes_QuestionTypeId",
                        column: x => x.QuestionTypeId,
                        principalTable: "TasteQuestionsTypes",
                        principalColumn: "TasteQuestionsTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TasteEvaluations",
                columns: table => new
                {
                    TasteEvaluationId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    WineId = table.Column<Guid>(type: "uuid", nullable: true),
                    EventId = table.Column<Guid>(type: "uuid", nullable: false),
                    WineScore = table.Column<float>(type: "real", nullable: false)
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WineGrapeTypeLinks",
                columns: table => new
                {
                    WineGrapeTypeLinkId = table.Column<Guid>(type: "uuid", nullable: false),
                    WineId = table.Column<Guid>(type: "uuid", nullable: false),
                    GrapeTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WineGrapeTypeLinks", x => x.WineGrapeTypeLinkId);
                    table.ForeignKey(
                        name: "FK_WineGrapeTypeLinks_GrapeTypes_GrapeTypeId",
                        column: x => x.GrapeTypeId,
                        principalTable: "GrapeTypes",
                        principalColumn: "GrapeTypeId");
                    table.ForeignKey(
                        name: "FK_WineGrapeTypeLinks_Wines_WineId",
                        column: x => x.WineId,
                        principalTable: "Wines",
                        principalColumn: "WineId");
                });

            migrationBuilder.CreateTable(
                name: "TasteQuestionOption",
                columns: table => new
                {
                    TasteQuestionOptionId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    OptionText = table.Column<string>(type: "text", nullable: false),
                    TasteQuestionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TasteQuestionOption", x => x.TasteQuestionOptionId);
                    table.ForeignKey(
                        name: "FK_TasteQuestionOption_TasteQuestions_TasteQuestionId",
                        column: x => x.TasteQuestionId,
                        principalTable: "TasteQuestions",
                        principalColumn: "TasteQuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TasteEvaluationQuestions",
                columns: table => new
                {
                    TasteEvaluationQuestionId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    TasteEvaluationId = table.Column<Guid>(type: "uuid", nullable: false),
                    TasteQuestionId = table.Column<Guid>(type: "uuid", nullable: false),
                    TasteQuestionOptionId = table.Column<Guid>(type: "uuid", nullable: true),
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
                        name: "FK_TasteEvaluationQuestions_TasteQuestionOption_TasteQuestionO~",
                        column: x => x.TasteQuestionOptionId,
                        principalTable: "TasteQuestionOption",
                        principalColumn: "TasteQuestionOptionId");
                    table.ForeignKey(
                        name: "FK_TasteEvaluationQuestions_TasteQuestions_TasteQuestionId",
                        column: x => x.TasteQuestionId,
                        principalTable: "TasteQuestions",
                        principalColumn: "TasteQuestionId",
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

            migrationBuilder.CreateIndex(
                name: "IX_TasteEvaluationQuestions_TasteEvaluationId",
                table: "TasteEvaluationQuestions",
                column: "TasteEvaluationId");

            migrationBuilder.CreateIndex(
                name: "IX_TasteEvaluationQuestions_TasteQuestionId",
                table: "TasteEvaluationQuestions",
                column: "TasteQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_TasteEvaluationQuestions_TasteQuestionOptionId",
                table: "TasteEvaluationQuestions",
                column: "TasteQuestionOptionId");

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

            migrationBuilder.CreateIndex(
                name: "IX_TasteQuestionOption_TasteQuestionId",
                table: "TasteQuestionOption",
                column: "TasteQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_TasteQuestions_EventId",
                table: "TasteQuestions",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_TasteQuestions_QuestionTypeId",
                table: "TasteQuestions",
                column: "QuestionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WineGrapeTypeLinks_GrapeTypeId",
                table: "WineGrapeTypeLinks",
                column: "GrapeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WineGrapeTypeLinks_WineId",
                table: "WineGrapeTypeLinks",
                column: "WineId");

            migrationBuilder.CreateIndex(
                name: "IX_Wines_BrandId",
                table: "Wines",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Wines_EventId",
                table: "Wines",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Wines_RegionId",
                table: "Wines",
                column: "RegionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.DropTable(
                name: "TasteEvaluationQuestions");

            migrationBuilder.DropTable(
                name: "WineGrapeTypeLinks");

            migrationBuilder.DropTable(
                name: "TasteEvaluations");

            migrationBuilder.DropTable(
                name: "TasteQuestionOption");

            migrationBuilder.DropTable(
                name: "GrapeTypes");

            migrationBuilder.DropTable(
                name: "Wines");

            migrationBuilder.DropTable(
                name: "TasteQuestions");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "TasteQuestionsTypes");
        }
    }
}
