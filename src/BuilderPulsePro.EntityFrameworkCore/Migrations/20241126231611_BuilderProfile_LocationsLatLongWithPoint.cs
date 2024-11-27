using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace BuilderPulsePro.Migrations
{
    /// <inheritdoc />
    public partial class BuilderProfile_LocationsLatLongWithPoint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Point>(
                name: "Coordinates",
                table: "BppLocations",
                type: "geometry",
                nullable: false)
                .Annotation("MySql:SpatialReferenceSystemId", 4326);

            migrationBuilder.CreateIndex(
                name: "IX_Location_Coordinates",
                table: "BppLocations",
                column: "Coordinates")
                .Annotation("MySql:SpatialIndex", true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Location_Coordinates",
                table: "BppLocations");

            migrationBuilder.DropColumn(
                name: "Coordinates",
                table: "BppLocations");
        }
    }
}
