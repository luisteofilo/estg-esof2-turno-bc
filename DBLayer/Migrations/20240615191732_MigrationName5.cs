using System;
using System.Collections.Generic;
using ESOF.WebApp.DBLayer.Entities;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESOF.WebApp.DBLayer.Migrations
{
    /// <inheritdoc />
    public partial class MigrationName5 : Migration
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
                name: "PostUserFavorite",
                columns: table => new
                {
                    FavoritePostId = table.Column<Guid>(type: "uuid", nullable: false),
                    FavoriteUserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostUserFavorite", x => new { x.FavoritePostId, x.FavoriteUserId });
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
                    PasswordSalt = table.Column<byte[]>(type: "bytea", nullable: false),
                    ReceivedPosts = table.Column<List<Tuple<Post, User>>>(type: "record[]", nullable: false),
                    SentPosts = table.Column<List<Tuple<Post, User>>>(type: "record[]", nullable: false)
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
                    VisibilityType = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UserId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    UserId2 = table.Column<Guid>(type: "uuid", nullable: true),
                    UserId3 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Posts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Posts_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Posts_Users_UserId2",
                        column: x => x.UserId2,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Posts_Users_UserId3",
                        column: x => x.UserId3,
                        principalTable: "Users",
                        principalColumn: "UserId");
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
                name: "UserUser",
                columns: table => new
                {
                    FollowersUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    FollowingUserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserUser", x => new { x.FollowersUserId, x.FollowingUserId });
                    table.ForeignKey(
                        name: "FK_UserUser_Users_FollowersUserId",
                        column: x => x.FollowersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserUser_Users_FollowingUserId",
                        column: x => x.FollowingUserId,
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
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId1",
                table: "Posts",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId2",
                table: "Posts",
                column: "UserId2");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId3",
                table: "Posts",
                column: "UserId3");

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

            migrationBuilder.CreateIndex(
                name: "IX_UserUser_FollowingUserId",
                table: "UserUser",
                column: "FollowingUserId");
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
                name: "UserUser");

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
