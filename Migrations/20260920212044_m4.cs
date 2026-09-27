using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tarea_6_SI1.Migrations
{
    /// <inheritdoc />
    public partial class m4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_activos_ActivosTecnologicos_Id_activo",
                table: "Ticket_activos");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_activos_Tickets_Id_Ticket",
                table: "Ticket_activos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ticket_activos",
                table: "Ticket_activos");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_activos_Id_Ticket",
                table: "Ticket_activos");

            migrationBuilder.DropColumn(
                name: "id_Ticket",
                table: "Ticket_activos");

            migrationBuilder.DropColumn(
                name: "id_activo",
                table: "Ticket_activos");

            migrationBuilder.RenameColumn(
                name: "Id_activo",
                table: "Ticket_activos",
                newName: "id_activo");

            migrationBuilder.RenameColumn(
                name: "Id_Ticket",
                table: "Ticket_activos",
                newName: "id_Ticket");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_activos_Id_activo",
                table: "Ticket_activos",
                newName: "IX_Ticket_activos_id_activo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ticket_activos",
                table: "Ticket_activos",
                columns: new[] { "id_Ticket", "id_activo" });

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_activos_ActivosTecnologicos_id_activo",
                table: "Ticket_activos",
                column: "id_activo",
                principalTable: "ActivosTecnologicos",
                principalColumn: "Id_Activo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_activos_Tickets_id_Ticket",
                table: "Ticket_activos",
                column: "id_Ticket",
                principalTable: "Tickets",
                principalColumn: "Id_Ticket",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_activos_ActivosTecnologicos_id_activo",
                table: "Ticket_activos");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_activos_Tickets_id_Ticket",
                table: "Ticket_activos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ticket_activos",
                table: "Ticket_activos");

            migrationBuilder.RenameColumn(
                name: "id_activo",
                table: "Ticket_activos",
                newName: "Id_activo");

            migrationBuilder.RenameColumn(
                name: "id_Ticket",
                table: "Ticket_activos",
                newName: "Id_Ticket");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_activos_id_activo",
                table: "Ticket_activos",
                newName: "IX_Ticket_activos_Id_activo");

            migrationBuilder.AddColumn<int>(
                name: "id_Ticket",
                table: "Ticket_activos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "id_activo",
                table: "Ticket_activos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ticket_activos",
                table: "Ticket_activos",
                columns: new[] { "id_Ticket", "id_activo" });

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_activos_Id_Ticket",
                table: "Ticket_activos",
                column: "Id_Ticket");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_activos_ActivosTecnologicos_Id_activo",
                table: "Ticket_activos",
                column: "Id_activo",
                principalTable: "ActivosTecnologicos",
                principalColumn: "Id_Activo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_activos_Tickets_Id_Ticket",
                table: "Ticket_activos",
                column: "Id_Ticket",
                principalTable: "Tickets",
                principalColumn: "Id_Ticket",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
