using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESOF.WebApp.DBLayer.Migrations
{
    /// <inheritdoc />
    public partial class ChangeFriendRequestStatusToText : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "FriendRequests");
            
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "FriendRequests",
                type: "text",
                nullable: false,
                defaultValue: "PENDING");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "FriendRequests");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "FriendRequests",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
