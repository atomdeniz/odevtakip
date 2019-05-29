using Microsoft.EntityFrameworkCore.Migrations;

namespace OdevTakip.Data.Migrations
{
    public partial class homeworkmigactive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Homeworks",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Homeworks");
        }
    }
}
