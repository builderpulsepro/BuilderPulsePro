using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace BuilderPulsePro.Migrations
{
    /// <inheritdoc />
    public partial class BuilderProfile_LocationsLatLongNoPoint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Location_Coordinates",
                table: "BppLocations");

            migrationBuilder.DropColumn(
                name: "Coordinates",
                table: "BppLocations");

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "BppLocations",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "BppLocations",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "BppLocations");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "BppLocations");

            migrationBuilder.AddColumn<Point>(
                name: "Coordinates",
                table: "BppLocations",
                type: "point",
                nullable: false)
                .Annotation("MySql:SpatialReferenceSystemId", 4326);

            migrationBuilder.CreateIndex(
                name: "IX_Location_Coordinates",
                table: "BppLocations",
                column: "Coordinates")
                .Annotation("MySql:SpatialIndex", true);
        }
    }
}
