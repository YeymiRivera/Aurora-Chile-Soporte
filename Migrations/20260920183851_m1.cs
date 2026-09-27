using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tarea_6_SI1.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaActualizacion",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "Tickets",
                newName: "Urgencia");

            migrationBuilder.RenameColumn(
                name: "FechaCreacion",
                table: "Tickets",
                newName: "Fecha");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tickets",
                newName: "Id_Ticket");

            migrationBuilder.AddColumn<string>(
                name: "CI_Usuario",
                table: "Tickets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Id_Area",
                table: "Tickets",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_Encargado",
                table: "Tickets",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_Sucursal",
                table: "Tickets",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_Usuario",
                table: "Tickets",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Impacto",
                table: "Tickets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Prioridad",
                table: "Tickets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tipo_Problema",
                table: "Tickets",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CI_Usuario",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Id_Area",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Id_Encargado",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Id_Sucursal",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Id_Usuario",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Impacto",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Prioridad",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Tipo_Problema",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "Urgencia",
                table: "Tickets",
                newName: "Titulo");

            migrationBuilder.RenameColumn(
                name: "Fecha",
                table: "Tickets",
                newName: "FechaCreacion");

            migrationBuilder.RenameColumn(
                name: "Id_Ticket",
                table: "Tickets",
                newName: "Id");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaActualizacion",
                table: "Tickets",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
