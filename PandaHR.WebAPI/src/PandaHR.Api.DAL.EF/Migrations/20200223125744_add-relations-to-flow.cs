using Microsoft.EntityFrameworkCore.Migrations;

namespace PandaHR.Api.DAL.EF.Migrations
{
    public partial class addrelationstoflow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CancelReason",
                table: "VacancyCVFlows");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CancelReason",
                table: "VacancyCVFlows",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
