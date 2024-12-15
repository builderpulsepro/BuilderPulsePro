using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuilderPulsePro.Migrations
{
    /// <inheritdoc />
    public partial class ProjectTaskDependencies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BppProjectTaskPrerequisites",
                columns: table => new
                {
                    DependentTaskId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PrerequisiteTaskId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BppProjectTaskPrerequisites", x => new { x.DependentTaskId, x.PrerequisiteTaskId });
                    table.ForeignKey(
                        name: "FK_BppProjectTaskPrerequisites_BppProjectTasks_DependentTaskId",
                        column: x => x.DependentTaskId,
                        principalTable: "BppProjectTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BppProjectTaskPrerequisites_BppProjectTasks_PrerequisiteTask~",
                        column: x => x.PrerequisiteTaskId,
                        principalTable: "BppProjectTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_BppProjectTaskPrerequisites_PrerequisiteTaskId",
                table: "BppProjectTaskPrerequisites",
                column: "PrerequisiteTaskId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BppProjectTaskPrerequisites");
        }
    }
}
