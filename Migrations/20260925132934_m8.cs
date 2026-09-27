using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Tarea_6_SI1.Migrations
{
    /// <inheritdoc />
    public partial class m8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Evidencias",
                columns: table => new
                {
                    Id_Evidencia = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_Ticket = table.Column<int>(type: "integer", nullable: false),
                    Id_Responsable = table.Column<int>(type: "integer", nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Tipo = table.Column<string>(type: "text", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    Archivo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evidencias", x => x.Id_Evidencia);
                    table.ForeignKey(
                        name: "FK_Evidencias_Tickets_id_Ticket",
                        column: x => x.id_Ticket,
                        principalTable: "Tickets",
                        principalColumn: "Id_Ticket",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ticket_repuestos",
                columns: table => new
                {
                    id_Ticket = table.Column<int>(type: "integer", nullable: false),
                    id_Repuesto = table.Column<int>(type: "integer", nullable: false),
                    Cantidad = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket_repuestos", x => new { x.id_Ticket, x.id_Repuesto });
                    table.ForeignKey(
                        name: "FK_Ticket_repuestos_Repuestos_id_Repuesto",
                        column: x => x.id_Repuesto,
                        principalTable: "Repuestos",
                        principalColumn: "Id_Respuesto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_repuestos_Tickets_id_Ticket",
                        column: x => x.id_Ticket,
                        principalTable: "Tickets",
                        principalColumn: "Id_Ticket",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Evidencias_id_Ticket",
                table: "Evidencias",
                column: "id_Ticket");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_repuestos_id_Repuesto",
                table: "Ticket_repuestos",
                column: "id_Repuesto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Evidencias");

            migrationBuilder.DropTable(
                name: "Ticket_repuestos");
        }
    }
}
