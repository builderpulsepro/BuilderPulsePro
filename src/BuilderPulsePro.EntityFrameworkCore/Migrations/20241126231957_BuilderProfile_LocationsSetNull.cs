using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuilderPulsePro.Migrations
{
    /// <inheritdoc />
    public partial class BuilderProfile_LocationsSetNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BppBuilderProfiles_BppLocations_LocationId",
                table: "BppBuilderProfiles");

            migrationBuilder.AddForeignKey(
                name: "FK_BppBuilderProfiles_BppLocations_LocationId",
                table: "BppBuilderProfiles",
                column: "LocationId",
                principalTable: "BppLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BppBuilderProfiles_BppLocations_LocationId",
                table: "BppBuilderProfiles");

            migrationBuilder.AddForeignKey(
                name: "FK_BppBuilderProfiles_BppLocations_LocationId",
                table: "BppBuilderProfiles",
                column: "LocationId",
                principalTable: "BppLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
