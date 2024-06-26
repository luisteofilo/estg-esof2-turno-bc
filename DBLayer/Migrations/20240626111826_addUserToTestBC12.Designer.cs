﻿// <auto-generated />
using System;
using ESOF.WebApp.DBLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ESOF.WebApp.DBLayer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240626111826_addUserToTestBC12")]
    partial class addUserToTestBC12
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.Brand", b =>
                {
                    b.Property<Guid>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("BrandId");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.Comment", b =>
                {
                    b.Property<Guid>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("CommentId");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.FriendRequest", b =>
                {
                    b.Property<Guid>("RequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ReceiverId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RequesterId")
                        .HasColumnType("uuid");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("RequestId");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("RequesterId");

                    b.ToTable("FriendRequests");
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.Friendship", b =>
                {
                    b.Property<Guid>("FriendshipId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId1")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId2")
                        .HasColumnType("uuid");

                    b.HasKey("FriendshipId");

                    b.HasIndex("UserId1");

                    b.HasIndex("UserId2");

                    b.ToTable("Friendships");
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.GrapeType", b =>
                {
                    b.Property<Guid>("GrapeTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("GrapeTypeId");

                    b.ToTable("GrapeTypes");
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.Hashtag", b =>
                {
                    b.Property<Guid>("HashtagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("NumPosts")
                        .HasColumnType("integer");

                    b.HasKey("HashtagId");

                    b.ToTable("Hashtags");
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.Like", b =>
                {
                    b.Property<Guid>("LikeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("LikeId");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.Permission", b =>
                {
                    b.Property<Guid>("PermissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PermissionId");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.Post", b =>
                {
                    b.Property<Guid>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CreatorId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("DateTimePost")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.Property<int>("VisibilityType")
                        .HasColumnType("integer");

                    b.HasKey("PostId");

                    b.HasIndex("CreatorId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.PostMedia", b =>
                {
                    b.Property<Guid>("MediaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<byte[]>("Data")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Filename")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("MediaPostId")
                        .HasColumnType("uuid");

                    b.HasKey("MediaId");

                    b.HasIndex("MediaPostId");

                    b.ToTable("PostMedia");
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.PostUserFavorite", b =>
                {
                    b.Property<Guid>("FavoritePostId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("FavoriteUserId")
                        .HasColumnType("uuid");

                    b.HasKey("FavoritePostId", "FavoriteUserId");

                    b.HasIndex("FavoriteUserId");

                    b.ToTable("PostUserFavorite");
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.PostUserHidden", b =>
                {
                    b.Property<Guid>("HiddenPostId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("HiddenUserId")
                        .HasColumnType("uuid");

                    b.HasKey("HiddenPostId", "HiddenUserId");

                    b.HasIndex("HiddenUserId");

                    b.ToTable("PostUserHidden");
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.PostUserShare", b =>
                {
                    b.Property<Guid>("SharedPostId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserSentId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserReceivedId")
                        .HasColumnType("uuid");

                    b.HasKey("SharedPostId", "UserSentId", "UserReceivedId");

                    b.HasIndex("UserReceivedId");

                    b.HasIndex("UserSentId");

                    b.ToTable("PostUserShare");
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.PostUserView", b =>
                {
                    b.Property<Guid>("ViewedPostId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ViewedUserId")
                        .HasColumnType("uuid");

                    b.HasKey("ViewedPostId", "ViewedUserId");

                    b.HasIndex("ViewedUserId");

                    b.ToTable("PostUserView");
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.Region", b =>
                {
                    b.Property<Guid>("RegionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("RegionId");

                    b.ToTable("Regions", (string)null);
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.Role", b =>
                {
                    b.Property<Guid>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.RolePermission", b =>
                {
                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PermissionId")
                        .HasColumnType("uuid");

                    b.HasKey("RoleId", "PermissionId");

                    b.HasIndex("PermissionId");

                    b.ToTable("RolePermissions");
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("FriendsCount")
                        .HasColumnType("integer");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.UserRole", b =>
                {
                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("RoleId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.Wine", b =>
                {
                    b.Property<Guid>("WineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<double?>("Alcohol")
                        .HasColumnType("double precision");

                    b.Property<Guid>("BrandId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LabelDesignation")
                        .HasColumnType("text");

                    b.Property<decimal?>("MaximumPrice")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("MinimumPrice")
                        .HasColumnType("numeric");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.Property<string>("category")
                        .HasColumnType("text");

                    b.Property<string>("label")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("WineId");

                    b.HasIndex("BrandId");

                    b.HasIndex("RegionId");

                    b.ToTable("Wines");
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.WineGrapeTypeLink", b =>
                {
                    b.Property<Guid>("WineGrapeTypeLinkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("GrapeTypeId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("WineId")
                        .HasColumnType("uuid");

                    b.HasKey("WineGrapeTypeLinkId");

                    b.HasIndex("GrapeTypeId");

                    b.HasIndex("WineId");

                    b.ToTable("WineGrapeTypeLinks");
                });

            modelBuilder.Entity("HashtagPost", b =>
                {
                    b.Property<Guid>("HashtagsHashtagId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PostsPostId")
                        .HasColumnType("uuid");

                    b.HasKey("HashtagsHashtagId", "PostsPostId");

                    b.HasIndex("PostsPostId");

                    b.ToTable("HashtagPost");
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.Comment", b =>
                {
                    b.HasOne("ESOF.WebApp.DBLayer.Entities.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ESOF.WebApp.DBLayer.Entities.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.FriendRequest", b =>
                {
                    b.HasOne("ESOF.WebApp.DBLayer.Entities.User", "Receiver")
                        .WithMany("ReceivedFriendshipRequests")
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ESOF.WebApp.DBLayer.Entities.User", "Requester")
                        .WithMany("SentFriendshipRequests")
                        .HasForeignKey("RequesterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Receiver");

                    b.Navigation("Requester");
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.Friendship", b =>
                {
                    b.HasOne("ESOF.WebApp.DBLayer.Entities.User", "User1")
                        .WithMany("Friendships1")
                        .HasForeignKey("UserId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ESOF.WebApp.DBLayer.Entities.User", "User2")
                        .WithMany("Friendships2")
                        .HasForeignKey("UserId2")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User1");

                    b.Navigation("User2");
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.Like", b =>
                {
                    b.HasOne("ESOF.WebApp.DBLayer.Entities.Post", "Post")
                        .WithMany("Likes")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ESOF.WebApp.DBLayer.Entities.User", "User")
                        .WithMany("Likes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.Post", b =>
                {
                    b.HasOne("ESOF.WebApp.DBLayer.Entities.User", "Creator")
                        .WithMany("Posts")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.PostMedia", b =>
                {
                    b.HasOne("ESOF.WebApp.DBLayer.Entities.Post", "MediaPost")
                        .WithMany("Media")
                        .HasForeignKey("MediaPostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MediaPost");
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.PostUserFavorite", b =>
                {
                    b.HasOne("ESOF.WebApp.DBLayer.Entities.Post", "FavoritePost")
                        .WithMany()
                        .HasForeignKey("FavoritePostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ESOF.WebApp.DBLayer.Entities.User", "FavoriteUser")
                        .WithMany()
                        .HasForeignKey("FavoriteUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FavoritePost");

                    b.Navigation("FavoriteUser");
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.PostUserHidden", b =>
                {
                    b.HasOne("ESOF.WebApp.DBLayer.Entities.Post", "HiddenPost")
                        .WithMany()
                        .HasForeignKey("HiddenPostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ESOF.WebApp.DBLayer.Entities.User", "HiddenUser")
                        .WithMany()
                        .HasForeignKey("HiddenUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HiddenPost");

                    b.Navigation("HiddenUser");
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.PostUserShare", b =>
                {
                    b.HasOne("ESOF.WebApp.DBLayer.Entities.Post", "SharedPost")
                        .WithMany()
                        .HasForeignKey("SharedPostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ESOF.WebApp.DBLayer.Entities.User", "UserReceived")
                        .WithMany()
                        .HasForeignKey("UserReceivedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ESOF.WebApp.DBLayer.Entities.User", "UserSent")
                        .WithMany()
                        .HasForeignKey("UserSentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SharedPost");

                    b.Navigation("UserReceived");

                    b.Navigation("UserSent");
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.PostUserView", b =>
                {
                    b.HasOne("ESOF.WebApp.DBLayer.Entities.Post", "ViewedPost")
                        .WithMany()
                        .HasForeignKey("ViewedPostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ESOF.WebApp.DBLayer.Entities.User", "ViewedUser")
                        .WithMany()
                        .HasForeignKey("ViewedUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ViewedPost");

                    b.Navigation("ViewedUser");
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.RolePermission", b =>
                {
                    b.HasOne("ESOF.WebApp.DBLayer.Entities.Permission", "Permission")
                        .WithMany("RolePermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ESOF.WebApp.DBLayer.Entities.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.UserRole", b =>
                {
                    b.HasOne("ESOF.WebApp.DBLayer.Entities.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ESOF.WebApp.DBLayer.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.Wine", b =>
                {
                    b.HasOne("ESOF.WebApp.DBLayer.Entities.Brand", "Brand")
                        .WithMany("Wines")
                        .HasForeignKey("BrandId");

                    b.HasOne("ESOF.WebApp.DBLayer.Entities.Region", "Region")
                        .WithMany("Wines")
                        .HasForeignKey("RegionId");

                    b.Navigation("Brand");

                    b.Navigation("Region");
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.WineGrapeTypeLink", b =>
                {
                    b.HasOne("ESOF.WebApp.DBLayer.Entities.GrapeType", "GrapeType")
                        .WithMany("WineGrapeTypes")
                        .HasForeignKey("GrapeTypeId");

                    b.HasOne("ESOF.WebApp.DBLayer.Entities.Wine", "Wine")
                        .WithMany("WineGrapeTypeLinks")
                        .HasForeignKey("WineId");

                    b.Navigation("GrapeType");

                    b.Navigation("Wine");
                });

            modelBuilder.Entity("HashtagPost", b =>
                {
                    b.HasOne("ESOF.WebApp.DBLayer.Entities.Hashtag", null)
                        .WithMany()
                        .HasForeignKey("HashtagsHashtagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ESOF.WebApp.DBLayer.Entities.Post", null)
                        .WithMany()
                        .HasForeignKey("PostsPostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.Brand", b =>
                {
                    b.Navigation("Wines");
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.GrapeType", b =>
                {
                    b.Navigation("WineGrapeTypes");
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.Permission", b =>
                {
                    b.Navigation("RolePermissions");
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.Post", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Likes");

                    b.Navigation("Media");
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.Region", b =>
                {
                    b.Navigation("Wines");
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.Role", b =>
                {
                    b.Navigation("RolePermissions");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Friendships1");

                    b.Navigation("Friendships2");

                    b.Navigation("Likes");

                    b.Navigation("Posts");

                    b.Navigation("ReceivedFriendshipRequests");

                    b.Navigation("SentFriendshipRequests");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.Wine", b =>
                {
                    b.Navigation("WineGrapeTypeLinks");
                });
#pragma warning restore 612, 618
        }
    }
}
