using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESOF.WebApp.DBLayer.Migrations
{
    /// <inheritdoc />
    public partial class Feed_Post_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Follows",
                columns: table => new
                {
                    FollowerUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserFollowedId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Follows", x => new { x.FollowerUserId, x.UserFollowedId });
                    table.ForeignKey(
                        name: "FK_Follows_Users_FollowerUserId",
                        column: x => x.FollowerUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Follows_Users_UserFollowedId",
                        column: x => x.UserFollowedId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hashtags",
                columns: table => new
                {
                    HashtagId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    NumPosts = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hashtags", x => x.HashtagId);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateTimePost = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: true),
                    VisibilityType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Posts_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HashtagPost",
                columns: table => new
                {
                    HashtagsHashtagId = table.Column<Guid>(type: "uuid", nullable: false),
                    PostsPostId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HashtagPost", x => new { x.HashtagsHashtagId, x.PostsPostId });
                    table.ForeignKey(
                        name: "FK_HashtagPost_Hashtags_HashtagsHashtagId",
                        column: x => x.HashtagsHashtagId,
                        principalTable: "Hashtags",
                        principalColumn: "HashtagId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HashtagPost_Posts_PostsPostId",
                        column: x => x.PostsPostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostMedia",
                columns: table => new
                {
                    MediaId = table.Column<Guid>(type: "uuid", nullable: false),
                    MediaPostId = table.Column<Guid>(type: "uuid", nullable: false),
                    Filename = table.Column<string>(type: "text", nullable: false),
                    FileExtension = table.Column<string>(type: "text", nullable: false),
                    Data = table.Column<byte[]>(type: "bytea", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostMedia", x => x.MediaId);
                    table.ForeignKey(
                        name: "FK_PostMedia_Posts_MediaPostId",
                        column: x => x.MediaPostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostUserFavorite",
                columns: table => new
                {
                    FavoritePostId = table.Column<Guid>(type: "uuid", nullable: false),
                    FavoriteUserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostUserFavorite", x => new { x.FavoritePostId, x.FavoriteUserId });
                    table.ForeignKey(
                        name: "FK_PostUserFavorite_Posts_FavoritePostId",
                        column: x => x.FavoritePostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostUserFavorite_Users_FavoriteUserId",
                        column: x => x.FavoriteUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostUserHidden",
                columns: table => new
                {
                    HiddenPostId = table.Column<Guid>(type: "uuid", nullable: false),
                    HiddenUserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostUserHidden", x => new { x.HiddenPostId, x.HiddenUserId });
                    table.ForeignKey(
                        name: "FK_PostUserHidden_Posts_HiddenPostId",
                        column: x => x.HiddenPostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostUserHidden_Users_HiddenUserId",
                        column: x => x.HiddenUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostUserShare",
                columns: table => new
                {
                    SharedPostId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserSentId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserReceivedId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostUserShare", x => new { x.SharedPostId, x.UserSentId, x.UserReceivedId });
                    table.ForeignKey(
                        name: "FK_PostUserShare_Posts_SharedPostId",
                        column: x => x.SharedPostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostUserShare_Users_UserReceivedId",
                        column: x => x.UserReceivedId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostUserShare_Users_UserSentId",
                        column: x => x.UserSentId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostUserView",
                columns: table => new
                {
                    ViewedPostId = table.Column<Guid>(type: "uuid", nullable: false),
                    ViewedUserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostUserView", x => new { x.ViewedPostId, x.ViewedUserId });
                    table.ForeignKey(
                        name: "FK_PostUserView_Posts_ViewedPostId",
                        column: x => x.ViewedPostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostUserView_Users_ViewedUserId",
                        column: x => x.ViewedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Follows_UserFollowedId",
                table: "Follows",
                column: "UserFollowedId");

            migrationBuilder.CreateIndex(
                name: "IX_HashtagPost_PostsPostId",
                table: "HashtagPost",
                column: "PostsPostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostMedia_MediaPostId",
                table: "PostMedia",
                column: "MediaPostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CreatorId",
                table: "Posts",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_PostUserFavorite_FavoriteUserId",
                table: "PostUserFavorite",
                column: "FavoriteUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostUserHidden_HiddenUserId",
                table: "PostUserHidden",
                column: "HiddenUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostUserShare_UserReceivedId",
                table: "PostUserShare",
                column: "UserReceivedId");

            migrationBuilder.CreateIndex(
                name: "IX_PostUserShare_UserSentId",
                table: "PostUserShare",
                column: "UserSentId");

            migrationBuilder.CreateIndex(
                name: "IX_PostUserView_ViewedUserId",
                table: "PostUserView",
                column: "ViewedUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Follows");

            migrationBuilder.DropTable(
                name: "HashtagPost");

            migrationBuilder.DropTable(
                name: "PostMedia");

            migrationBuilder.DropTable(
                name: "PostUserFavorite");

            migrationBuilder.DropTable(
                name: "PostUserHidden");

            migrationBuilder.DropTable(
                name: "PostUserShare");

            migrationBuilder.DropTable(
                name: "PostUserView");

            migrationBuilder.DropTable(
                name: "Hashtags");

            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
