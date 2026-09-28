using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tarea_6_SI1.Migrations
{
    /// <inheritdoc />
    public partial class m12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id_Area",
                table: "ActivosTecnologicos");

            migrationBuilder.DropColumn(
                name: "Id_Responsable",
                table: "ActivosTecnologicos");

            migrationBuilder.DropColumn(
                name: "Id_Sucursal",
                table: "ActivosTecnologicos");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Fecha_Vencimiento_Garantia",
                table: "ActivosTecnologicos",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Fecha_Compra",
                table: "ActivosTecnologicos",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha_Vencimiento_Garantia",
                table: "ActivosTecnologicos",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha_Compra",
                table: "ActivosTecnologicos",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<int>(
                name: "Id_Area",
                table: "ActivosTecnologicos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_Responsable",
                table: "ActivosTecnologicos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_Sucursal",
                table: "ActivosTecnologicos",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
