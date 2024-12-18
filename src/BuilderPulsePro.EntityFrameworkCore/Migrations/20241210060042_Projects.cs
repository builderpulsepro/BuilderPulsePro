using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuilderPulsePro.Migrations
{
    /// <inheritdoc />
    public partial class Projects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BppProjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Title = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    BuilderProfileID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ClientUserID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ExtraProperties = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BppProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BppProjects_AbpUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BppProjects_AbpUsers_DeleterId",
                        column: x => x.DeleterId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BppProjects_AbpUsers_LastModifierId",
                        column: x => x.LastModifierId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BppProjects_BppBuilderProfiles_BuilderProfileID",
                        column: x => x.BuilderProfileID,
                        principalTable: "BppBuilderProfiles",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BppProjectTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Title = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TaskType = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsAppointment = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ProjectId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ContractorProfileId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BppProjectTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BppProjectTasks_BppContractorProfiles_ContractorProfileId",
                        column: x => x.ContractorProfileId,
                        principalTable: "BppContractorProfiles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BppProjectTasks_BppProjects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "BppProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_BppProjects_BuilderProfileID",
                table: "BppProjects",
                column: "BuilderProfileID");

            migrationBuilder.CreateIndex(
                name: "IX_BppProjects_CreatorId",
                table: "BppProjects",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_BppProjects_DeleterId",
                table: "BppProjects",
                column: "DeleterId");

            migrationBuilder.CreateIndex(
                name: "IX_BppProjects_LastModifierId",
                table: "BppProjects",
                column: "LastModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_BppProjectTasks_ContractorProfileId",
                table: "BppProjectTasks",
                column: "ContractorProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_BppProjectTasks_ProjectId",
                table: "BppProjectTasks",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BppProjectTasks");

            migrationBuilder.DropTable(
                name: "BppProjects");
        }
    }
}
