using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalConsultation.Repository.Migrations
{
    /// <inheritdoc />
    public partial class V2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyScheduleItem");

            migrationBuilder.DropColumn(
                name: "Day",
                table: "Horario");

            migrationBuilder.RenameColumn(
                name: "Hour",
                table: "Horario",
                newName: "Hora");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HorariosDiaSemana");

            migrationBuilder.RenameColumn(
                name: "Hora",
                table: "Horario",
                newName: "Hour");

            migrationBuilder.AddColumn<int>(
                name: "Day",
                table: "Horario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DailyScheduleItem",
                columns: table => new
                {
                    DailyScheduleEntityId = table.Column<int>(type: "INT", nullable: false),
                    TimeEntityId = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyScheduleItem", x => new { x.DailyScheduleEntityId, x.TimeEntityId });
                    table.ForeignKey(
                        name: "FK_DailyScheduleItem_HorarioDia_DailyScheduleEntityId",
                        column: x => x.DailyScheduleEntityId,
                        principalTable: "HorarioDia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DailyScheduleItem_Horario_TimeEntityId",
                        column: x => x.TimeEntityId,
                        principalTable: "Horario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyScheduleItem_TimeEntityId",
                table: "DailyScheduleItem",
                column: "TimeEntityId");
        }
    }
}
