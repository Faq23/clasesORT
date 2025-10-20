using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Obligatorio.LogicaInfraestructura.Migrations
{
    /// <inheritdoc />
    public partial class fixAuditoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NombreUsuario",
                table: "Auditorias",
                newName: "EmailUsuario");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaAccion",
                table: "Auditorias",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaAccion",
                table: "Auditorias");

            migrationBuilder.RenameColumn(
                name: "EmailUsuario",
                table: "Auditorias",
                newName: "NombreUsuario");
        }
    }
}
