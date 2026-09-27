using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tarea_6_SI1.Migrations
{
    /// <inheritdoc />
    public partial class m11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id_Responsable",
                table: "Mantenimientos");

            migrationBuilder.AddColumn<string>(
                name: "Codigo_Responsable",
                table: "Mantenimientos",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Codigo_Responsable",
                table: "Mantenimientos");

            migrationBuilder.AddColumn<int>(
                name: "Id_Responsable",
                table: "Mantenimientos",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
