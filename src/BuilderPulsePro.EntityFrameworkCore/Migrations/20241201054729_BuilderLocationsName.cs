using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuilderPulsePro.Migrations
{
    /// <inheritdoc />
    public partial class BuilderLocationsName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BppLocations_BppBuilderProfiles_BuilderProfileId",
                table: "BppLocations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BppLocations",
                table: "BppLocations");

            migrationBuilder.RenameTable(
                name: "BppLocations",
                newName: "BppBuilderLocations");

            migrationBuilder.RenameIndex(
                name: "IX_BppLocations_BuilderProfileId",
                table: "BppBuilderLocations",
                newName: "IX_BppBuilderLocations_BuilderProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BppBuilderLocations",
                table: "BppBuilderLocations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BppBuilderLocations_BppBuilderProfiles_BuilderProfileId",
                table: "BppBuilderLocations",
                column: "BuilderProfileId",
                principalTable: "BppBuilderProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BppBuilderLocations_BppBuilderProfiles_BuilderProfileId",
                table: "BppBuilderLocations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BppBuilderLocations",
                table: "BppBuilderLocations");

            migrationBuilder.RenameTable(
                name: "BppBuilderLocations",
                newName: "BppLocations");

            migrationBuilder.RenameIndex(
                name: "IX_BppBuilderLocations_BuilderProfileId",
                table: "BppLocations",
                newName: "IX_BppLocations_BuilderProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BppLocations",
                table: "BppLocations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BppLocations_BppBuilderProfiles_BuilderProfileId",
                table: "BppLocations",
                column: "BuilderProfileId",
                principalTable: "BppBuilderProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
