using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PandaHR.Api.DAL.EF.Migrations
{
    public partial class OneCVPerUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CVs_AspNetUsers_UserId",
                table: "CVs");

            migrationBuilder.DropIndex(
                name: "IX_CVs_UserId",
                table: "CVs");

            migrationBuilder.AddColumn<Guid>(
                name: "CVId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CVs_AspNetUsers_Id",
                table: "CVs",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CVs_AspNetUsers_Id",
                table: "CVs");

            migrationBuilder.DropColumn(
                name: "CVId",
                table: "AspNetUsers");

            migrationBuilder.CreateIndex(
                name: "IX_CVs_UserId",
                table: "CVs",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CVs_AspNetUsers_UserId",
                table: "CVs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
