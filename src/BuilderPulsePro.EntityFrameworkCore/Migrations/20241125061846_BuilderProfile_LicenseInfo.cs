using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuilderPulsePro.Migrations
{
    /// <inheritdoc />
    public partial class BuilderProfile_LicenseInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BusinessLicenseNumber",
                table: "BppBuilderProfiles",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "IsVerified",
                table: "BppBuilderProfiles",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "IssuingAuthority",
                table: "BppBuilderProfiles",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "IssuingState",
                table: "BppBuilderProfiles",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusinessLicenseNumber",
                table: "BppBuilderProfiles");

            migrationBuilder.DropColumn(
                name: "IsVerified",
                table: "BppBuilderProfiles");

            migrationBuilder.DropColumn(
                name: "IssuingAuthority",
                table: "BppBuilderProfiles");

            migrationBuilder.DropColumn(
                name: "IssuingState",
                table: "BppBuilderProfiles");
        }
    }
}
