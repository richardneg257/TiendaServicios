﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiendaServicios.Api.CarritoCompra.Migrations
{
    /// <inheritdoc />
    public partial class CarritoCompraMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarritoSesion",
                columns: table => new
                {
                    CarritoSesionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarritoSesion", x => x.CarritoSesionId);
                });

            migrationBuilder.CreateTable(
                name: "CarritoSesionDetalle",
                columns: table => new
                {
                    CarritoSesionDetalleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LibroSeleccionado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarritoSesionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarritoSesionDetalle", x => x.CarritoSesionDetalleId);
                    table.ForeignKey(
                        name: "FK_CarritoSesionDetalle_CarritoSesion_CarritoSesionId",
                        column: x => x.CarritoSesionId,
                        principalTable: "CarritoSesion",
                        principalColumn: "CarritoSesionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarritoSesionDetalle_CarritoSesionId",
                table: "CarritoSesionDetalle",
                column: "CarritoSesionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarritoSesionDetalle");

            migrationBuilder.DropTable(
                name: "CarritoSesion");
        }
    }
}
