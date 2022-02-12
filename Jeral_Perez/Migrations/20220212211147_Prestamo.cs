using Microsoft.EntityFrameworkCore.Migrations;

namespace Jeral_Perez.Migrations
{
    public partial class Prestamo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Plazo",
                table: "Prestamo",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Plazo",
                table: "Prestamo");
        }
    }
}
