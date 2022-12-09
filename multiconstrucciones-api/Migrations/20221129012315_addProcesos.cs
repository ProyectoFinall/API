using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace multiconstruccionesapi.Migrations
{
    /// <inheritdoc />
    public partial class addProcesos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClvProceso",
                table: "Viga",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClvProceso",
                table: "Viga");
        }
    }
}
