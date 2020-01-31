using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PandaHR.Api.DAL.EF.Migrations
{
    public partial class testSetNullableUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CVs_Users_UserId",
                table: "CVs");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SkillRequirements");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "SkillKnowledgeType");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SkillKnowledges");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "KnowledgeLevels");

            migrationBuilder.AddColumn<int>(
                name: "Value",
                table: "SkillKnowledgeType",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "CVs",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_CVs_Users_UserId",
                table: "CVs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CVs_Users_UserId",
                table: "CVs");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "SkillKnowledgeType");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "SkillRequirements",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "SkillKnowledgeType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "SkillKnowledges",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Value",
                table: "KnowledgeLevels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "CVs",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "KnowledgeLevels",
                keyColumn: "Id",
                keyValue: new Guid("32832ec4-968b-4619-b8cb-af4e65c52a37"),
                column: "Value",
                value: 2);

            migrationBuilder.UpdateData(
                table: "KnowledgeLevels",
                keyColumn: "Id",
                keyValue: new Guid("9b9be3ca-2c11-4afe-9c5f-225bbf192e31"),
                column: "Value",
                value: 3);

            migrationBuilder.UpdateData(
                table: "KnowledgeLevels",
                keyColumn: "Id",
                keyValue: new Guid("9b9be3ca-2c11-4afe-9c5f-225bbf192e81"),
                column: "Value",
                value: 1);

            migrationBuilder.UpdateData(
                table: "KnowledgeLevels",
                keyColumn: "Id",
                keyValue: new Guid("9b9be3ca-9c11-4afe-9c5f-225bbf192e81"),
                column: "Value",
                value: 4);

            migrationBuilder.AddForeignKey(
                name: "FK_CVs_Users_UserId",
                table: "CVs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
