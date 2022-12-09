using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace multiconstruccionesapi.Migrations
{
    /// <inheritdoc />
    public partial class nuevoPeso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PesoViga",
                table: "Proceso_Detalle",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PesoViga",
                table: "Proceso_Detalle");

            migrationBuilder.AddColumn<int>(
                name: "ObraClvObra",
                table: "Viga",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Viga_ObraClvObra",
                table: "Viga",
                column: "ObraClvObra");

            migrationBuilder.AddForeignKey(
                name: "FK_Viga_Obra_ObraClvObra",
                table: "Viga",
                column: "ObraClvObra",
                principalTable: "Obra",
                principalColumn: "ClvObra");
        }
    }
}
