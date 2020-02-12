using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PandaHR.Api.DAL.EF.Migrations
{
    public partial class changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkillKnowledgeType_KnowledgeLevels_KnowledgeLevelId",
                table: "SkillKnowledgeType");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillKnowledgeType_SkillTypes_SkillTypeId",
                table: "SkillKnowledgeType");

            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_Cities_CityId",
                table: "Vacancies");

            migrationBuilder.DropIndex(
                name: "IX_Vacancies_CityId",
                table: "Vacancies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SkillKnowledgeType",
                table: "SkillKnowledgeType");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Vacancies");

            migrationBuilder.RenameTable(
                name: "SkillKnowledgeType",
                newName: "SkillKnowledgeTypes");

            migrationBuilder.RenameIndex(
                name: "IX_SkillKnowledgeType_KnowledgeLevelId",
                table: "SkillKnowledgeTypes",
                newName: "IX_SkillKnowledgeTypes_KnowledgeLevelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SkillKnowledgeTypes",
                table: "SkillKnowledgeTypes",
                columns: new[] { "SkillTypeId", "KnowledgeLevelId" });

            migrationBuilder.CreateTable(
                name: "VacancyCities",
                columns: table => new
                {
                    VacancyId = table.Column<Guid>(nullable: false),
                    CityId = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacancyCities", x => new { x.VacancyId, x.CityId });
                    table.ForeignKey(
                        name: "FK_VacancyCities_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VacancyCities_Vacancies_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "Vacancies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VacancyCities_CityId",
                table: "VacancyCities",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillKnowledgeTypes_KnowledgeLevels_KnowledgeLevelId",
                table: "SkillKnowledgeTypes",
                column: "KnowledgeLevelId",
                principalTable: "KnowledgeLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillKnowledgeTypes_SkillTypes_SkillTypeId",
                table: "SkillKnowledgeTypes",
                column: "SkillTypeId",
                principalTable: "SkillTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkillKnowledgeTypes_KnowledgeLevels_KnowledgeLevelId",
                table: "SkillKnowledgeTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillKnowledgeTypes_SkillTypes_SkillTypeId",
                table: "SkillKnowledgeTypes");

            migrationBuilder.DropTable(
                name: "VacancyCities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SkillKnowledgeTypes",
                table: "SkillKnowledgeTypes");

            migrationBuilder.RenameTable(
                name: "SkillKnowledgeTypes",
                newName: "SkillKnowledgeType");

            migrationBuilder.RenameIndex(
                name: "IX_SkillKnowledgeTypes_KnowledgeLevelId",
                table: "SkillKnowledgeType",
                newName: "IX_SkillKnowledgeType_KnowledgeLevelId");

            migrationBuilder.AddColumn<Guid>(
                name: "CityId",
                table: "Vacancies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SkillKnowledgeType",
                table: "SkillKnowledgeType",
                columns: new[] { "SkillTypeId", "KnowledgeLevelId" });

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_CityId",
                table: "Vacancies",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillKnowledgeType_KnowledgeLevels_KnowledgeLevelId",
                table: "SkillKnowledgeType",
                column: "KnowledgeLevelId",
                principalTable: "KnowledgeLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillKnowledgeType_SkillTypes_SkillTypeId",
                table: "SkillKnowledgeType",
                column: "SkillTypeId",
                principalTable: "SkillTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_Cities_CityId",
                table: "Vacancies",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
