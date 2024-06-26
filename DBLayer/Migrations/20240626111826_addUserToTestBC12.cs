using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESOF.WebApp.DBLayer.Migrations
{
    /// <inheritdoc />
    public partial class addUserToTestBC12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "UserName", "Email", "PasswordHash", "PasswordSalt", "FriendsCount" },
                values: new object[]
                {
                    new Guid("9d957de9-df3a-4c68-9a93-617b43b1bcfd"), "TESTE123", "teste123@gmail.com", new byte[0],
                    new byte[0], 0
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("9d957de9-df3a-4c68-9a93-617b43b1bcfd"));
        }
    }
}
