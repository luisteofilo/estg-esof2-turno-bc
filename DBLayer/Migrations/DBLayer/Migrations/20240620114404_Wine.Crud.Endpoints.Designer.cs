using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ESOF.WebApp.DBLayer.Migrations
{
    public partial class WineCrudEndpoints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "GrapeTypes",
                columns: table => new
                {
                    GrapeTypeId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrapeTypes", x => x.GrapeTypeId);
                });
            
            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    RegionId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.RegionId);
                });
            
            migrationBuilder.CreateTable(
                name: "Wines",
                columns: table => new
                {
                    WineId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    BrandId = table.Column<Guid>(type: "uuid", nullable: false),
                    RegionId = table.Column<Guid>(type: "uuid", nullable: false),
                    label = table.Column<string>(type: "text", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    category = table.Column<string>(type: "text", nullable: true),
                    LabelDesignation = table.Column<string>(type: "text", nullable: true),
                    Alcohol = table.Column<double>(type: "double precision", nullable: true),
                    MinimumPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    MaximumPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wines", x => x.WineId);
                    table.ForeignKey(
                        name: "FK_Wines_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId");
                    table.ForeignKey(
                        name: "FK_Wines_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "RegionId");
                });
            
            migrationBuilder.CreateTable(
                name: "WineGrapeTypeLinks",
                columns: table => new
                {
                    WineGrapeTypeLinkId = table.Column<Guid>(type: "uuid", nullable: false),
                    WineId = table.Column<Guid>(type: "uuid", nullable: false),
                    GrapeTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WineGrapeTypeLinks", x => x.WineGrapeTypeLinkId);
                    table.ForeignKey(
                        name: "FK_WineGrapeTypeLinks_GrapeTypes_GrapeTypeId",
                        column: x => x.GrapeTypeId,
                        principalTable: "GrapeTypes",
                        principalColumn: "GrapeTypeId");
                    table.ForeignKey(
                        name: "FK_WineGrapeTypeLinks_Wines_WineId",
                        column: x => x.WineId,
                        principalTable: "Wines",
                        principalColumn: "WineId");
                });
            
            migrationBuilder.CreateIndex(
                name: "IX_WineGrapeTypeLinks_GrapeTypeId",
                table: "WineGrapeTypeLinks",
                column: "GrapeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WineGrapeTypeLinks_WineId",
                table: "WineGrapeTypeLinks",
                column: "WineId");

            migrationBuilder.CreateIndex(
                name: "IX_Wines_BrandId",
                table: "Wines",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Wines_RegionId",
                table: "Wines",
                column: "RegionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WineGrapeTypeLinks");
            
            migrationBuilder.DropTable(
                name: "GrapeTypes");

            migrationBuilder.DropTable(
                name: "Wines");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
