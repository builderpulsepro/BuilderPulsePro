using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuilderPulsePro.Migrations
{
    /// <inheritdoc />
    public partial class BuilderProfile_AddWithUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_BppBuilderProfiles_CreatorId",
                table: "BppBuilderProfiles",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_BppBuilderProfiles_DeleterId",
                table: "BppBuilderProfiles",
                column: "DeleterId");

            migrationBuilder.CreateIndex(
                name: "IX_BppBuilderProfiles_LastModifierId",
                table: "BppBuilderProfiles",
                column: "LastModifierId");

            migrationBuilder.AddForeignKey(
                name: "FK_BppBuilderProfiles_AbpUsers_CreatorId",
                table: "BppBuilderProfiles",
                column: "CreatorId",
                principalTable: "AbpUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BppBuilderProfiles_AbpUsers_DeleterId",
                table: "BppBuilderProfiles",
                column: "DeleterId",
                principalTable: "AbpUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BppBuilderProfiles_AbpUsers_LastModifierId",
                table: "BppBuilderProfiles",
                column: "LastModifierId",
                principalTable: "AbpUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BppBuilderProfiles_AbpUsers_CreatorId",
                table: "BppBuilderProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_BppBuilderProfiles_AbpUsers_DeleterId",
                table: "BppBuilderProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_BppBuilderProfiles_AbpUsers_LastModifierId",
                table: "BppBuilderProfiles");

            migrationBuilder.DropIndex(
                name: "IX_BppBuilderProfiles_CreatorId",
                table: "BppBuilderProfiles");

            migrationBuilder.DropIndex(
                name: "IX_BppBuilderProfiles_DeleterId",
                table: "BppBuilderProfiles");

            migrationBuilder.DropIndex(
                name: "IX_BppBuilderProfiles_LastModifierId",
                table: "BppBuilderProfiles");
        }
    }
}
