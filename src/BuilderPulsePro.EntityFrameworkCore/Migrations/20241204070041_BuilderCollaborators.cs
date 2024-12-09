using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuilderPulsePro.Migrations
{
    /// <inheritdoc />
    public partial class BuilderCollaborators : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BppBuilderCollaboratorInvitations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    BuilderProfileId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    EmailAddress = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsAccepted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    InvitationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BppBuilderCollaboratorInvitations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BppBuilderCollaboratorInvitations_BppBuilderProfiles_Builder~",
                        column: x => x.BuilderProfileId,
                        principalTable: "BppBuilderProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BppBuilderCollaborators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    BuilderProfileId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BppBuilderCollaborators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BppBuilderCollaborators_BppBuilderProfiles_BuilderProfileId",
                        column: x => x.BuilderProfileId,
                        principalTable: "BppBuilderProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_BppBuilderCollaboratorInvitations_BuilderProfileId",
                table: "BppBuilderCollaboratorInvitations",
                column: "BuilderProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_BppBuilderCollaborators_BuilderProfileId",
                table: "BppBuilderCollaborators",
                column: "BuilderProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BppBuilderCollaboratorInvitations");

            migrationBuilder.DropTable(
                name: "BppBuilderCollaborators");
        }
    }
}
