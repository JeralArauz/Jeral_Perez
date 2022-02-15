﻿// <auto-generated />
using System;
using Jeral_Perez.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Jeral_Perez.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Jeral_Perez.Models.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<DateTime>("FechaReg")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Sexo")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("UserReg")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("IdCliente");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Jeral_Perez.Models.Pagos", b =>
                {
                    b.Property<int?>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaPago")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdPago")
                        .HasColumnType("int");

                    b.Property<int>("IdPrestamo")
                        .HasColumnType("int");

                    b.Property<decimal>("MontoPagado")
                        .HasColumnType("decimal(12,2)");

                    b.Property<decimal>("Saldo")
                        .HasColumnType("decimal(12,2)");

                    b.Property<string>("UserReg")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pagos");
                });

            modelBuilder.Entity("Jeral_Perez.Models.Prestamo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaReg")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("Interes")
                        .HasColumnType("int");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(12,2)");

                    b.Property<int>("Plazo")
                        .HasColumnType("int");

                    b.Property<decimal>("Saldo")
                        .HasColumnType("decimal(12,2)");

                    b.Property<decimal>("TotalDeuda")
                        .HasColumnType("decimal(12,2)");

                    b.Property<string>("UserReg")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdCliente");

                    b.ToTable("Prestamo");
                });

            modelBuilder.Entity("Jeral_Perez.Models.Pagos", b =>
                {
                    b.HasOne("Jeral_Perez.Models.Prestamo", "Prestamo")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Jeral_Perez.Models.Prestamo", b =>
                {
                    b.HasOne("Jeral_Perez.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
