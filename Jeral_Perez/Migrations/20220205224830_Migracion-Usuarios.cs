using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Jeral_Perez.Migrations
{
    public partial class MigracionUsuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(maxLength: 100, nullable: false),
                    Apellidos = table.Column<string>(maxLength: 100, nullable: false),
                    Cedula = table.Column<string>(maxLength: 100, nullable: false),
                    Direccion = table.Column<string>(maxLength: 500, nullable: false),
                    Telefono = table.Column<string>(maxLength: 50, nullable: true),
                    Sexo = table.Column<string>(maxLength: 20, nullable: true),
                    FechaReg = table.Column<DateTime>(nullable: false),
                    UserReg = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
