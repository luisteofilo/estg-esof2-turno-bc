using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ESOF.WebApp.DBLayer.Migrations
{
    /// <inheritdoc />
    public partial class FeedPostHasEventAndWine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EventId",
                table: "Posts",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "WineId",
                table: "Posts",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_EventId",
                table: "Posts",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_WineId",
                table: "Posts",
                column: "WineId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Events_EventId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Wines_WineId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_EventId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_WineId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "WineId",
                table: "Posts");
        }
    }
}
