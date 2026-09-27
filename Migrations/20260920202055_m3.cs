using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Tarea_6_SI1.Migrations
{
    /// <inheritdoc />
    public partial class m3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivosTecnologicos",
                columns: table => new
                {
                    Id_Activo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Codigo_Inventario = table.Column<string>(type: "text", nullable: false),
                    Marca = table.Column<string>(type: "text", nullable: false),
                    Modelo = table.Column<string>(type: "text", nullable: false),
                    Numero_Serie = table.Column<string>(type: "text", nullable: false),
                    Fecha_Compra = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Fecha_Vencimiento_Garantia = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Estado = table.Column<string>(type: "text", nullable: false),
                    Id_Area = table.Column<int>(type: "integer", nullable: false),
                    Id_Sucursal = table.Column<int>(type: "integer", nullable: false),
                    Id_Responsable = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivosTecnologicos", x => x.Id_Activo);
                });

            migrationBuilder.CreateTable(
                name: "Diagnosticos",
                columns: table => new
                {
                    Id_Diagnostico = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id_Encargado = table.Column<int>(type: "integer", nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    Resultado = table.Column<string>(type: "text", nullable: false),
                    Causa = table.Column<string>(type: "text", nullable: false),
                    Observaciones = table.Column<string>(type: "text", nullable: false),
                    id_Ticket = table.Column<int>(type: "integer", nullable: false),
                    Id_Ticket = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnosticos", x => x.Id_Diagnostico);
                    table.ForeignKey(
                        name: "FK_Diagnosticos_Tickets_Id_Ticket",
                        column: x => x.Id_Ticket,
                        principalTable: "Tickets",
                        principalColumn: "Id_Ticket",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ticket_activos",
                columns: table => new
                {
                    id_Ticket = table.Column<int>(type: "integer", nullable: false),
                    id_activo = table.Column<int>(type: "integer", nullable: false),
                    Id_Ticket = table.Column<int>(type: "integer", nullable: false),
                    Id_activo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket_activos", x => new { x.id_Ticket, x.id_activo });
                    table.ForeignKey(
                        name: "FK_Ticket_activos_ActivosTecnologicos_Id_activo",
                        column: x => x.Id_activo,
                        principalTable: "ActivosTecnologicos",
                        principalColumn: "Id_Activo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_activos_Tickets_Id_Ticket",
                        column: x => x.Id_Ticket,
                        principalTable: "Tickets",
                        principalColumn: "Id_Ticket",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diagnosticos_Id_Ticket",
                table: "Diagnosticos",
                column: "Id_Ticket");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_activos_Id_activo",
                table: "Ticket_activos",
                column: "Id_activo");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_activos_Id_Ticket",
                table: "Ticket_activos",
                column: "Id_Ticket");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diagnosticos");

            migrationBuilder.DropTable(
                name: "Ticket_activos");

            migrationBuilder.DropTable(
                name: "ActivosTecnologicos");
        }
    }
}
