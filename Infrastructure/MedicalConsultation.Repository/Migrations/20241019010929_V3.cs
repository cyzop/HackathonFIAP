using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalConsultation.Repository.Migrations
{
    /// <inheritdoc />
    public partial class V3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Medico");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Paciente",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Medico",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
