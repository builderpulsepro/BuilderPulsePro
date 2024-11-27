using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace BuilderPulsePro.Migrations
{
    /// <inheritdoc />
    public partial class BuilderProfile_Locations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LocationId",
                table: "BppBuilderProfiles",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateTable(
                name: "BppLocations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Street1 = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Street2 = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    State = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ZipCode = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Country = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Coordinates = table.Column<Point>(type: "point", nullable: false)
                        .Annotation("MySql:SpatialReferenceSystemId", 4326)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BppLocations", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_BppBuilderProfiles_LocationId",
                table: "BppBuilderProfiles",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_Coordinates",
                table: "BppLocations",
                column: "Coordinates")
                .Annotation("MySql:SpatialIndex", true);

            migrationBuilder.AddForeignKey(
                name: "FK_BppBuilderProfiles_BppLocations_LocationId",
                table: "BppBuilderProfiles",
                column: "LocationId",
                principalTable: "BppLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BppBuilderProfiles_BppLocations_LocationId",
                table: "BppBuilderProfiles");

            migrationBuilder.DropTable(
                name: "BppLocations");

            migrationBuilder.DropIndex(
                name: "IX_BppBuilderProfiles_LocationId",
                table: "BppBuilderProfiles");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "BppBuilderProfiles");
        }
    }
}
