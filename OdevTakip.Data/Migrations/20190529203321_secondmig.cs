using Microsoft.EntityFrameworkCore.Migrations;

namespace OdevTakip.Data.Migrations
{
    public partial class secondmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Year",
                table: "Lessons",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Year",
                table: "Lessons",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
