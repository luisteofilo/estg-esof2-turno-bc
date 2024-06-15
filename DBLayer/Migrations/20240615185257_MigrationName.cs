using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESOF.WebApp.DBLayer.Migrations
{
    /// <inheritdoc />
    public partial class MigrationName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostMedia_Posts_MediaPostId",
                table: "PostMedia");

            migrationBuilder.DropForeignKey(
                name: "FK_PostUserFavorite_Posts_FavoritePostId",
                table: "PostUserFavorite");

            migrationBuilder.DropForeignKey(
                name: "FK_PostUserFavorite_Users_FavoriteUserId",
                table: "PostUserFavorite");

            migrationBuilder.DropForeignKey(
                name: "FK_PostUserHidden_Posts_HiddenPostId",
                table: "PostUserHidden");

            migrationBuilder.DropForeignKey(
                name: "FK_PostUserHidden_Users_HiddenUserId",
                table: "PostUserHidden");

            migrationBuilder.DropForeignKey(
                name: "FK_PostUserShare_Posts_SharedPostId",
                table: "PostUserShare");

            migrationBuilder.DropForeignKey(
                name: "FK_PostUserView_Posts_ViewedPostId",
                table: "PostUserView");

            migrationBuilder.DropForeignKey(
                name: "FK_PostUserView_Users_ViewedUserId",
                table: "PostUserView");

            migrationBuilder.DropIndex(
                name: "IX_PostUserView_ViewedUserId",
                table: "PostUserView");

            migrationBuilder.DropIndex(
                name: "IX_PostUserHidden_HiddenUserId",
                table: "PostUserHidden");

            migrationBuilder.DropIndex(
                name: "IX_PostUserFavorite_FavoriteUserId",
                table: "PostUserFavorite");

            migrationBuilder.DropIndex(
                name: "IX_PostMedia_MediaPostId",
                table: "PostMedia");

            migrationBuilder.AddColumn<Guid>(
                name: "PostVPostId",
                table: "PostUserView",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserVUserId",
                table: "PostUserView",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PostSPostId",
                table: "PostUserShare",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PostHPostId",
                table: "PostUserHidden",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserHUserId",
                table: "PostUserHidden",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PostFPostId",
                table: "PostUserFavorite",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserFUserId",
                table: "PostUserFavorite",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PostMPostId",
                table: "PostMedia",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_PostUserView_PostVPostId",
                table: "PostUserView",
                column: "PostVPostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostUserView_UserVUserId",
                table: "PostUserView",
                column: "UserVUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostUserShare_PostSPostId",
                table: "PostUserShare",
                column: "PostSPostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostUserHidden_PostHPostId",
                table: "PostUserHidden",
                column: "PostHPostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostUserHidden_UserHUserId",
                table: "PostUserHidden",
                column: "UserHUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostUserFavorite_PostFPostId",
                table: "PostUserFavorite",
                column: "PostFPostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostUserFavorite_UserFUserId",
                table: "PostUserFavorite",
                column: "UserFUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostMedia_PostMPostId",
                table: "PostMedia",
                column: "PostMPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostMedia_Posts_PostMPostId",
                table: "PostMedia",
                column: "PostMPostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostUserFavorite_Posts_PostFPostId",
                table: "PostUserFavorite",
                column: "PostFPostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostUserFavorite_Users_UserFUserId",
                table: "PostUserFavorite",
                column: "UserFUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostUserHidden_Posts_PostHPostId",
                table: "PostUserHidden",
                column: "PostHPostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostUserHidden_Users_UserHUserId",
                table: "PostUserHidden",
                column: "UserHUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostUserShare_Posts_PostSPostId",
                table: "PostUserShare",
                column: "PostSPostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostUserView_Posts_PostVPostId",
                table: "PostUserView",
                column: "PostVPostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostUserView_Users_UserVUserId",
                table: "PostUserView",
                column: "UserVUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostMedia_Posts_PostMPostId",
                table: "PostMedia");

            migrationBuilder.DropForeignKey(
                name: "FK_PostUserFavorite_Posts_PostFPostId",
                table: "PostUserFavorite");

            migrationBuilder.DropForeignKey(
                name: "FK_PostUserFavorite_Users_UserFUserId",
                table: "PostUserFavorite");

            migrationBuilder.DropForeignKey(
                name: "FK_PostUserHidden_Posts_PostHPostId",
                table: "PostUserHidden");

            migrationBuilder.DropForeignKey(
                name: "FK_PostUserHidden_Users_UserHUserId",
                table: "PostUserHidden");

            migrationBuilder.DropForeignKey(
                name: "FK_PostUserShare_Posts_PostSPostId",
                table: "PostUserShare");

            migrationBuilder.DropForeignKey(
                name: "FK_PostUserView_Posts_PostVPostId",
                table: "PostUserView");

            migrationBuilder.DropForeignKey(
                name: "FK_PostUserView_Users_UserVUserId",
                table: "PostUserView");

            migrationBuilder.DropIndex(
                name: "IX_PostUserView_PostVPostId",
                table: "PostUserView");

            migrationBuilder.DropIndex(
                name: "IX_PostUserView_UserVUserId",
                table: "PostUserView");

            migrationBuilder.DropIndex(
                name: "IX_PostUserShare_PostSPostId",
                table: "PostUserShare");

            migrationBuilder.DropIndex(
                name: "IX_PostUserHidden_PostHPostId",
                table: "PostUserHidden");

            migrationBuilder.DropIndex(
                name: "IX_PostUserHidden_UserHUserId",
                table: "PostUserHidden");

            migrationBuilder.DropIndex(
                name: "IX_PostUserFavorite_PostFPostId",
                table: "PostUserFavorite");

            migrationBuilder.DropIndex(
                name: "IX_PostUserFavorite_UserFUserId",
                table: "PostUserFavorite");

            migrationBuilder.DropIndex(
                name: "IX_PostMedia_PostMPostId",
                table: "PostMedia");

            migrationBuilder.DropColumn(
                name: "PostVPostId",
                table: "PostUserView");

            migrationBuilder.DropColumn(
                name: "UserVUserId",
                table: "PostUserView");

            migrationBuilder.DropColumn(
                name: "PostSPostId",
                table: "PostUserShare");

            migrationBuilder.DropColumn(
                name: "PostHPostId",
                table: "PostUserHidden");

            migrationBuilder.DropColumn(
                name: "UserHUserId",
                table: "PostUserHidden");

            migrationBuilder.DropColumn(
                name: "PostFPostId",
                table: "PostUserFavorite");

            migrationBuilder.DropColumn(
                name: "UserFUserId",
                table: "PostUserFavorite");

            migrationBuilder.DropColumn(
                name: "PostMPostId",
                table: "PostMedia");

            migrationBuilder.CreateIndex(
                name: "IX_PostUserView_ViewedUserId",
                table: "PostUserView",
                column: "ViewedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostUserHidden_HiddenUserId",
                table: "PostUserHidden",
                column: "HiddenUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostUserFavorite_FavoriteUserId",
                table: "PostUserFavorite",
                column: "FavoriteUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostMedia_MediaPostId",
                table: "PostMedia",
                column: "MediaPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostMedia_Posts_MediaPostId",
                table: "PostMedia",
                column: "MediaPostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostUserFavorite_Posts_FavoritePostId",
                table: "PostUserFavorite",
                column: "FavoritePostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostUserFavorite_Users_FavoriteUserId",
                table: "PostUserFavorite",
                column: "FavoriteUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostUserHidden_Posts_HiddenPostId",
                table: "PostUserHidden",
                column: "HiddenPostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostUserHidden_Users_HiddenUserId",
                table: "PostUserHidden",
                column: "HiddenUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostUserShare_Posts_SharedPostId",
                table: "PostUserShare",
                column: "SharedPostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostUserView_Posts_ViewedPostId",
                table: "PostUserView",
                column: "ViewedPostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostUserView_Users_ViewedUserId",
                table: "PostUserView",
                column: "ViewedUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
