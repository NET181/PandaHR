using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PandaHR.Api.DAL.EF.Migrations
{
    public partial class VacancyCVWorkflow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VacancyCVFlows",
                columns: table => new
                {
                    CVId = table.Column<Guid>(nullable: false),
                    VacancyId = table.Column<Guid>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CancelReason = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacancyCVFlows", x => new { x.CVId, x.VacancyId });
                    table.UniqueConstraint("AK_VacancyCVFlows_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VacancyCVFlows_CVs_CVId",
                        column: x => x.CVId,
                        principalTable: "CVs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VacancyCVFlows_Vacancies_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "Vacancies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VacancyCVFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    VacancyCVFlowId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacancyCVFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VacancyCVFiles_VacancyCVFlows_VacancyCVFlowId",
                        column: x => x.VacancyCVFlowId,
                        principalTable: "VacancyCVFlows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VacancyCVFiles_VacancyCVFlowId",
                table: "VacancyCVFiles",
                column: "VacancyCVFlowId");

            migrationBuilder.CreateIndex(
                name: "IX_VacancyCVFlows_VacancyId",
                table: "VacancyCVFlows",
                column: "VacancyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VacancyCVFiles");

            migrationBuilder.DropTable(
                name: "VacancyCVFlows");
        }
    }
}
