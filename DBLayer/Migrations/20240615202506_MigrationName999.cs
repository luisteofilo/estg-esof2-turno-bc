using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESOF.WebApp.DBLayer.Migrations
{
    /// <inheritdoc />
    public partial class MigrationName999 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Permissions",
                columns: table => new
                {
                    PermissionId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.PermissionId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "bytea", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "bytea", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    PermissionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => new { x.RoleId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_RolePermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "PermissionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateTimePost = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
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
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.RoleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
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
                    PostMPostId = table.Column<Guid>(type: "uuid", nullable: false),
                    Filename = table.Column<string>(type: "text", nullable: false),
                    FileExtension = table.Column<string>(type: "text", nullable: false),
                    Data = table.Column<byte[]>(type: "bytea", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostMedia", x => x.MediaId);
                    table.ForeignKey(
                        name: "FK_PostMedia_Posts_PostMPostId",
                        column: x => x.PostMPostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostUserFavorite",
                columns: table => new
                {
                    FavoritePostId = table.Column<Guid>(type: "uuid", nullable: false),
                    FavoriteUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    PostFPostId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserFUserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostUserFavorite", x => new { x.FavoritePostId, x.FavoriteUserId });
                    table.ForeignKey(
                        name: "FK_PostUserFavorite_Posts_PostFPostId",
                        column: x => x.PostFPostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostUserFavorite_Users_UserFUserId",
                        column: x => x.UserFUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostUserHidden",
                columns: table => new
                {
                    HiddenPostId = table.Column<Guid>(type: "uuid", nullable: false),
                    HiddenUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    PostHPostId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserHUserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostUserHidden", x => new { x.HiddenPostId, x.HiddenUserId });
                    table.ForeignKey(
                        name: "FK_PostUserHidden_Posts_PostHPostId",
                        column: x => x.PostHPostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostUserHidden_Users_UserHUserId",
                        column: x => x.UserHUserId,
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
                    UserReceivedId = table.Column<Guid>(type: "uuid", nullable: false),
                    PostSPostId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostUserShare", x => new { x.SharedPostId, x.UserSentId, x.UserReceivedId });
                    table.ForeignKey(
                        name: "FK_PostUserShare_Posts_PostSPostId",
                        column: x => x.PostSPostId,
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
                    ViewedUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    PostVPostId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserVUserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostUserView", x => new { x.ViewedPostId, x.ViewedUserId });
                    table.ForeignKey(
                        name: "FK_PostUserView_Posts_PostVPostId",
                        column: x => x.PostVPostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostUserView_Users_UserVUserId",
                        column: x => x.UserVUserId,
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
                name: "IX_PostMedia_PostMPostId",
                table: "PostMedia",
                column: "PostMPostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CreatorId",
                table: "Posts",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_PostUserFavorite_PostFPostId",
                table: "PostUserFavorite",
                column: "PostFPostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostUserFavorite_UserFUserId",
                table: "PostUserFavorite",
                column: "UserFUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostUserHidden_PostHPostId",
                table: "PostUserHidden",
                column: "PostHPostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostUserHidden_UserHUserId",
                table: "PostUserHidden",
                column: "UserHUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostUserShare_PostSPostId",
                table: "PostUserShare",
                column: "PostSPostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostUserShare_UserReceivedId",
                table: "PostUserShare",
                column: "UserReceivedId");

            migrationBuilder.CreateIndex(
                name: "IX_PostUserShare_UserSentId",
                table: "PostUserShare",
                column: "UserSentId");

            migrationBuilder.CreateIndex(
                name: "IX_PostUserView_PostVPostId",
                table: "PostUserView",
                column: "PostVPostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostUserView_UserVUserId",
                table: "PostUserView",
                column: "UserVUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_PermissionId",
                table: "RolePermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
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
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Hashtags");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
