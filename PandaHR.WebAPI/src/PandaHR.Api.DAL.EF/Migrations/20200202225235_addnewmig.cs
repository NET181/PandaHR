using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PandaHR.Api.DAL.EF.Migrations
{
    public partial class addnewmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "KnowledgeLevels",
                keyColumn: "Id",
                keyValue: new Guid("32832ec4-968b-4619-b8cb-af4e65c52a37"));

            migrationBuilder.DeleteData(
                table: "KnowledgeLevels",
                keyColumn: "Id",
                keyValue: new Guid("9b9be3ca-2c11-4afe-9c5f-225bbf192e31"));

            migrationBuilder.DeleteData(
                table: "KnowledgeLevels",
                keyColumn: "Id",
                keyValue: new Guid("9b9be3ca-2c11-4afe-9c5f-225bbf192e81"));

            migrationBuilder.DeleteData(
                table: "KnowledgeLevels",
                keyColumn: "Id",
                keyValue: new Guid("9b9be3ca-9c11-4afe-9c5f-225bbf192e81"));

            migrationBuilder.AddColumn<int>(
                name: "Value",
                table: "SkillTypes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "SkillTypes");

            migrationBuilder.InsertData(
                table: "KnowledgeLevels",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("9b9be3ca-2c11-4afe-9c5f-225bbf192e81"), false, "Beginer" },
                    { new Guid("32832ec4-968b-4619-b8cb-af4e65c52a37"), false, "Lower Intermidiate" },
                    { new Guid("9b9be3ca-2c11-4afe-9c5f-225bbf192e31"), false, "Intermidiate" },
                    { new Guid("9b9be3ca-9c11-4afe-9c5f-225bbf192e81"), false, "Upper Intermidiate" }
                });
        }
    }
}
