using System;
using Microsoft.EntityFrameworkCore.Migrations;
using ESOF.WebApp.DBLayer.Helpers;

#nullable disable

namespace ESOF.WebApp.DBLayer.Migrations
{
    /// <inheritdoc />
    public partial class WineTinder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interaction",
                columns: table => new
                {
                    InteractionLinkId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    WineId = table.Column<Guid>(type: "uuid", nullable: false),
                    InteractionType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interaction", x => x.InteractionLinkId);
                    table.ForeignKey(
                        name: "FK_Interaction_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Interaction_Wines_WineId",
                        column: x => x.WineId,
                        principalTable: "Wines",
                        principalColumn: "WineId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interaction_UserId",
                table: "Interaction",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Interaction_WineId",
                table: "Interaction",
                column: "WineId");
            
            var adminUserId = Guid.NewGuid();
            var normalUserId = Guid.NewGuid();
            PasswordHelper.CreatePasswordHash("root", out byte[] adminPasswordHash, out byte[] adminPasswordSalt);
            PasswordHelper.CreatePasswordHash("normal", out byte[] normalPasswordHash, out byte[] normalPasswordSalt);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "PasswordHash", "PasswordSalt" },
                values: new object[,]
                {
                    { adminUserId, "root@example.com", adminPasswordHash, adminPasswordSalt },
                    { normalUserId, "normal@example.com", normalPasswordHash, normalPasswordSalt }
                });
        }
        
        

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Interaction");
        }
    }
}
