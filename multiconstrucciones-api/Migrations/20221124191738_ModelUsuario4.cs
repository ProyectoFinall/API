using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace multiconstruccionesapi.Migrations
{
    /// <inheritdoc />
    public partial class ModelUsuario4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey(
                name: "PK__Usuario__355616BEF08982B0",
                table: "Usuarios",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK__Usuario__355616BEF08982B0",
                table: "Usuarios");
        }
    }
}
