using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Tarea_6_SI1.Migrations
{
    /// <inheritdoc />
    public partial class m7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diagnosticos_Tickets_Id_Ticket",
                table: "Diagnosticos");

            migrationBuilder.DropIndex(
                name: "IX_Diagnosticos_Id_Ticket",
                table: "Diagnosticos");

            migrationBuilder.DropColumn(
                name: "Id_Ticket",
                table: "Diagnosticos");

            migrationBuilder.AddColumn<int>(
                name: "id_tipo_activo",
                table: "ActivosTecnologicos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Mantenimientos",
                columns: table => new
                {
                    Id_Mantenimiento = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id_Responsable = table.Column<int>(type: "integer", nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Tipo = table.Column<string>(type: "text", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    Costo = table.Column<decimal>(type: "numeric", nullable: false),
                    Observaciones = table.Column<string>(type: "text", nullable: false),
                    Estado = table.Column<string>(type: "text", nullable: false),
                    id_Activo = table.Column<int>(type: "integer", nullable: false),
                    id_Ticket = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mantenimientos", x => x.Id_Mantenimiento);
                    table.ForeignKey(
                        name: "FK_Mantenimientos_ActivosTecnologicos_id_Activo",
                        column: x => x.id_Activo,
                        principalTable: "ActivosTecnologicos",
                        principalColumn: "Id_Activo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mantenimientos_Tickets_id_Ticket",
                        column: x => x.id_Ticket,
                        principalTable: "Tickets",
                        principalColumn: "Id_Ticket",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Repuestos",
                columns: table => new
                {
                    Id_Respuesto = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Codigo = table.Column<string>(type: "text", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    Stock = table.Column<int>(type: "integer", nullable: false),
                    Costo = table.Column<decimal>(type: "numeric", nullable: false),
                    Estado = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repuestos", x => x.Id_Respuesto);
                });

            migrationBuilder.CreateTable(
                name: "Tipos_activos",
                columns: table => new
                {
                    Id_tipo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipos_activos", x => x.Id_tipo);
                });

            migrationBuilder.CreateTable(
                name: "Mantenimiento_repuestos",
                columns: table => new
                {
                    id_Respuesto = table.Column<int>(type: "integer", nullable: false),
                    id_Mantenimiento = table.Column<int>(type: "integer", nullable: false),
                    Cantidad = table.Column<int>(type: "integer", nullable: false),
                    id_Repuesto = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mantenimiento_repuestos", x => new { x.id_Mantenimiento, x.id_Respuesto });
                    table.ForeignKey(
                        name: "FK_Mantenimiento_repuestos_Mantenimientos_id_Mantenimiento",
                        column: x => x.id_Mantenimiento,
                        principalTable: "Mantenimientos",
                        principalColumn: "Id_Mantenimiento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mantenimiento_repuestos_Repuestos_id_Repuesto",
                        column: x => x.id_Repuesto,
                        principalTable: "Repuestos",
                        principalColumn: "Id_Respuesto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diagnosticos_id_Ticket",
                table: "Diagnosticos",
                column: "id_Ticket");

            migrationBuilder.CreateIndex(
                name: "IX_ActivosTecnologicos_id_tipo_activo",
                table: "ActivosTecnologicos",
                column: "id_tipo_activo");

            migrationBuilder.CreateIndex(
                name: "IX_Mantenimiento_repuestos_id_Repuesto",
                table: "Mantenimiento_repuestos",
                column: "id_Repuesto");

            migrationBuilder.CreateIndex(
                name: "IX_Mantenimientos_id_Activo",
                table: "Mantenimientos",
                column: "id_Activo");

            migrationBuilder.CreateIndex(
                name: "IX_Mantenimientos_id_Ticket",
                table: "Mantenimientos",
                column: "id_Ticket");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivosTecnologicos_Tipos_activos_id_tipo_activo",
                table: "ActivosTecnologicos",
                column: "id_tipo_activo",
                principalTable: "Tipos_activos",
                principalColumn: "Id_tipo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnosticos_Tickets_id_Ticket",
                table: "Diagnosticos",
                column: "id_Ticket",
                principalTable: "Tickets",
                principalColumn: "Id_Ticket",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivosTecnologicos_Tipos_activos_id_tipo_activo",
                table: "ActivosTecnologicos");

            migrationBuilder.DropForeignKey(
                name: "FK_Diagnosticos_Tickets_id_Ticket",
                table: "Diagnosticos");

            migrationBuilder.DropTable(
                name: "Mantenimiento_repuestos");

            migrationBuilder.DropTable(
                name: "Tipos_activos");

            migrationBuilder.DropTable(
                name: "Mantenimientos");

            migrationBuilder.DropTable(
                name: "Repuestos");

            migrationBuilder.DropIndex(
                name: "IX_Diagnosticos_id_Ticket",
                table: "Diagnosticos");

            migrationBuilder.DropIndex(
                name: "IX_ActivosTecnologicos_id_tipo_activo",
                table: "ActivosTecnologicos");

            migrationBuilder.DropColumn(
                name: "id_tipo_activo",
                table: "ActivosTecnologicos");

            migrationBuilder.AddColumn<int>(
                name: "Id_Ticket",
                table: "Diagnosticos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Diagnosticos_Id_Ticket",
                table: "Diagnosticos",
                column: "Id_Ticket");

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnosticos_Tickets_Id_Ticket",
                table: "Diagnosticos",
                column: "Id_Ticket",
                principalTable: "Tickets",
                principalColumn: "Id_Ticket",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
