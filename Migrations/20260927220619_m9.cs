using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tarea_6_SI1.Migrations
{
    /// <inheritdoc />
    public partial class m9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "CI_Encargado",
                table: "Tickets",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CI_Encargado",
                table: "Tickets");

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
        }
    }
}
