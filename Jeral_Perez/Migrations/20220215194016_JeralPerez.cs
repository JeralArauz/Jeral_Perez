using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Jeral_Perez.Migrations
{
    public partial class JeralPerez : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    IdCliente = table.Column<int>(nullable: false)
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
                    table.PrimaryKey("PK_Clientes", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Prestamo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    Interes = table.Column<int>(nullable: false),
                    Plazo = table.Column<int>(nullable: false),
                    Estado = table.Column<string>(nullable: true),
                    TotalDeuda = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    Saldo = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    UserReg = table.Column<string>(nullable: true),
                    FechaReg = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prestamo_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    IdPago = table.Column<int>(nullable: false),
                    IdPrestamo = table.Column<int>(nullable: false),
                    MontoPagado = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    Saldo = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    FechaPago = table.Column<DateTime>(nullable: false),
                    UserReg = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagos_Prestamo_Id",
                        column: x => x.Id,
                        principalTable: "Prestamo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prestamo_IdCliente",
                table: "Prestamo",
                column: "IdCliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Prestamo");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
