using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESOF.WebApp.DBLayer.Migrations
{
    /// <inheritdoc />
    public partial class Migration_UserProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FavoriteWineId",
                table: "Users",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_FavoriteWineId",
                table: "Users",
                column: "FavoriteWineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Wines_FavoriteWineId",
                table: "Users",
                column: "FavoriteWineId",
                principalTable: "Wines",
                principalColumn: "WineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Wines_FavoriteWineId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_FavoriteWineId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FavoriteWineId",
                table: "Users");
        }
    }
}
