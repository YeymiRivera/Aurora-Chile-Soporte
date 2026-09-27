using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tarea_6_SI1.Migrations
{
    /// <inheritdoc />
    public partial class m10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Mantenimiento_repuestos",
                table: "Mantenimiento_repuestos");

            migrationBuilder.DropColumn(
                name: "id_Respuesto",
                table: "Mantenimiento_repuestos");

            migrationBuilder.RenameColumn(
                name: "Id_Respuesto",
                table: "Repuestos",
                newName: "Id_Repuesto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mantenimiento_repuestos",
                table: "Mantenimiento_repuestos",
                columns: new[] { "id_Mantenimiento", "id_Repuesto" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Mantenimiento_repuestos",
                table: "Mantenimiento_repuestos");

            migrationBuilder.RenameColumn(
                name: "Id_Repuesto",
                table: "Repuestos",
                newName: "Id_Respuesto");

            migrationBuilder.AddColumn<int>(
                name: "id_Respuesto",
                table: "Mantenimiento_repuestos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mantenimiento_repuestos",
                table: "Mantenimiento_repuestos",
                columns: new[] { "id_Mantenimiento", "id_Respuesto" });
        }
    }
}
