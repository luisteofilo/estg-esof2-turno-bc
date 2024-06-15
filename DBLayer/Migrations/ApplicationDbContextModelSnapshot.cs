﻿// <auto-generated />
using System;
using System.Collections.Generic;
using ESOF.WebApp.DBLayer.Context;
using ESOF.WebApp.DBLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ESOF.WebApp.DBLayer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.Follow", b =>
                {
                    b.Property<Guid>("FollowerUserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserFollowedId")
                        .HasColumnType("uuid");

                    b.HasKey("FollowerUserId", "UserFollowedId");

                    b.HasIndex("UserFollowedId");

                    b.ToTable("Follows");
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

                    b.Property<DateTime>("DateTimePost")
                        .HasColumnType("timestamp with time zone");

                    b.Property<List<Tuple<User, User>>>("ShareUsers")
                        .IsRequired()
                        .HasColumnType("record[]");

                    b.Property<string>("Text")
                        .IsRequired()
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

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<Guid?>("PostId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("PostId1")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("PostId2")
                        .HasColumnType("uuid");

                    b.HasKey("UserId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("PostId");

                    b.HasIndex("PostId1");

                    b.HasIndex("PostId2");

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

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.Follow", b =>
                {
                    b.HasOne("ESOF.WebApp.DBLayer.Entities.User", "FollowerUser")
                        .WithMany()
                        .HasForeignKey("FollowerUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ESOF.WebApp.DBLayer.Entities.User", "UserFollowed")
                        .WithMany()
                        .HasForeignKey("UserFollowedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FollowerUser");

                    b.Navigation("UserFollowed");
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.Post", b =>
                {
                    b.HasOne("ESOF.WebApp.DBLayer.Entities.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.PostMedia", b =>
                {
                    b.HasOne("ESOF.WebApp.DBLayer.Entities.Post", "Post")
                        .WithMany("Media")
                        .HasForeignKey("MediaPostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.PostUserFavorite", b =>
                {
                    b.HasOne("ESOF.WebApp.DBLayer.Entities.Post", "Post")
                        .WithMany()
                        .HasForeignKey("FavoritePostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ESOF.WebApp.DBLayer.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("FavoriteUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.PostUserHidden", b =>
                {
                    b.HasOne("ESOF.WebApp.DBLayer.Entities.Post", "Post")
                        .WithMany()
                        .HasForeignKey("HiddenPostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ESOF.WebApp.DBLayer.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("HiddenUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.PostUserShare", b =>
                {
                    b.HasOne("ESOF.WebApp.DBLayer.Entities.Post", "Post")
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

                    b.Navigation("Post");

                    b.Navigation("UserReceived");

                    b.Navigation("UserSent");
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.PostUserView", b =>
                {
                    b.HasOne("ESOF.WebApp.DBLayer.Entities.Post", "Post")
                        .WithMany()
                        .HasForeignKey("ViewedPostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ESOF.WebApp.DBLayer.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("ViewedUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
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

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.User", b =>
                {
                    b.HasOne("ESOF.WebApp.DBLayer.Entities.Post", null)
                        .WithMany("FavoriteUsers")
                        .HasForeignKey("PostId");

                    b.HasOne("ESOF.WebApp.DBLayer.Entities.Post", null)
                        .WithMany("HiddenUsers")
                        .HasForeignKey("PostId1");

                    b.HasOne("ESOF.WebApp.DBLayer.Entities.Post", null)
                        .WithMany("ViewUsers")
                        .HasForeignKey("PostId2");
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

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.Permission", b =>
                {
                    b.Navigation("RolePermissions");
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.Post", b =>
                {
                    b.Navigation("FavoriteUsers");

                    b.Navigation("HiddenUsers");

                    b.Navigation("Media");

                    b.Navigation("ViewUsers");
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.Role", b =>
                {
                    b.Navigation("RolePermissions");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.User", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
