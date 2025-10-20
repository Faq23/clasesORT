using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Obligatorio.LogicaInfraestructura.Migrations
{
    /// <inheritdoc />
    public partial class Correciones_Pago : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaFin",
                table: "Pagos",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaInicio",
                table: "Pagos",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaPago",
                table: "Pagos",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumeroRecibo",
                table: "Pagos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoPago",
                table: "Pagos",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaFin",
                table: "Pagos");

            migrationBuilder.DropColumn(
                name: "FechaInicio",
                table: "Pagos");

            migrationBuilder.DropColumn(
                name: "FechaPago",
                table: "Pagos");

            migrationBuilder.DropColumn(
                name: "NumeroRecibo",
                table: "Pagos");

            migrationBuilder.DropColumn(
                name: "TipoPago",
                table: "Pagos");
        }
    }
}
