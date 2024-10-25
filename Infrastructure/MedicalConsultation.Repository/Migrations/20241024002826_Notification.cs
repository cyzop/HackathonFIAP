using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalConsultation.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Notification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HorariosDiaSemana");

            migrationBuilder.DropTable(
                name: "HorarioDia");

            migrationBuilder.DropTable(
                name: "Horario");

            migrationBuilder.CreateTable(
                name: "Notificacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "VARCHAR(250)", nullable: false),
                    Data = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    ConsultaId = table.Column<int>(type: "INT", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notificacao_Consulta_ConsultaId",
                        column: x => x.ConsultaId,
                        principalTable: "Consulta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notificacao_ConsultaId",
                table: "Notificacao",
                column: "ConsultaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notificacao");

            migrationBuilder.CreateTable(
                name: "Horario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DiaDaSemana = table.Column<int>(type: "int", nullable: false),
                    Hora = table.Column<TimeSpan>(type: "TIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HorarioDia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DiaDaSemana = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorarioDia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HorariosDiaSemana",
                columns: table => new
                {
                    HorarioDiaId = table.Column<int>(type: "INT", nullable: false),
                    HorarioId = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorariosDiaSemana", x => new { x.HorarioDiaId, x.HorarioId });
                    table.ForeignKey(
                        name: "FK_HorariosDiaSemana_HorarioDia_HorarioDiaId",
                        column: x => x.HorarioDiaId,
                        principalTable: "HorarioDia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HorariosDiaSemana_Horario_HorarioId",
                        column: x => x.HorarioId,
                        principalTable: "Horario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HorariosDiaSemana_HorarioId",
                table: "HorariosDiaSemana",
                column: "HorarioId");
        }
    }
}
