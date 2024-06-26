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
    [Migration("20240622230739_TasteEvaluations")]
    partial class TasteEvaluations
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

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.TasteEvaluation", b =>
                {
                    b.Property<Guid>("TasteEvaluationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("WineId")
                        .HasColumnType("uuid");

                    b.Property<int>("WineScore")
                        .HasColumnType("integer");

                    b.HasKey("TasteEvaluationId");

                    b.HasIndex("UserId");

                    b.HasIndex("WineId");

                    b.ToTable("TasteEvaluations");
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.TasteEvaluationQuestion", b =>
                {
                    b.Property<Guid>("TasteEvaluationQuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<Guid>("TasteEvaluationId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TasteQuestionId")
                        .HasColumnType("uuid");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("TasteEvaluationQuestionId");

                    b.HasIndex("TasteEvaluationId");

                    b.HasIndex("TasteQuestionId");

                    b.ToTable("TasteEvaluationQuestions");
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.TasteQuestion", b =>
                {
                    b.Property<Guid>("TasteQuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("TasteQuestionTypeId")
                        .HasColumnType("uuid");

                    b.HasKey("TasteQuestionId");

                    b.HasIndex("TasteQuestionTypeId");

                    b.ToTable("TasteQuestions");
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.TasteQuestionType", b =>
                {
                    b.Property<Guid>("TasteQuestionTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("TasteQuestionTypeId");

                    b.ToTable("TasteQuestionTypes");
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.HasKey("UserId");

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

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.TasteEvaluation", b =>
                {
                    b.HasOne("ESOF.WebApp.DBLayer.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ESOF.WebApp.DBLayer.Entities.Wine", "Wine")
                        .WithMany()
                        .HasForeignKey("WineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("Wine");
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.TasteEvaluationQuestion", b =>
                {
                    b.HasOne("ESOF.WebApp.DBLayer.Entities.TasteEvaluation", "TasteEvaluation")
                        .WithMany()
                        .HasForeignKey("TasteEvaluationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ESOF.WebApp.DBLayer.Entities.TasteQuestion", "TasteQuestion")
                        .WithMany()
                        .HasForeignKey("TasteQuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TasteEvaluation");

                    b.Navigation("TasteQuestion");
                });

            modelBuilder.Entity("ESOF.WebApp.DBLayer.Entities.TasteQuestion", b =>
                {
                    b.HasOne("ESOF.WebApp.DBLayer.Entities.TasteQuestionType", "TasteQuestionType")
                        .WithMany()
                        .HasForeignKey("TasteQuestionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TasteQuestionType");
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
