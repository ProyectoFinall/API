using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace multiconstruccionesapi.Migrations
{
    /// <inheritdoc />
    public partial class InitBd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Defectos",
                columns: table => new
                {
                    ClvDefecto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Defectos", x => x.ClvDefecto);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    NumEmpleado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomEmpleado = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    APaterno = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    AMaterno = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Puesto = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Empleado__750AE395C1EF9E85", x => x.NumEmpleado);
                });

            migrationBuilder.CreateTable(
                name: "Obra",
                columns: table => new
                {
                    ClvObra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomObra = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CantidadVigas = table.Column<int>(type: "int", nullable: false),
                    FechaObra = table.Column<DateTime>(type: "datetime", nullable: false),
                    NumEmpleado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Obra__355616BEF08982B0", x => x.ClvObra);
                });

            migrationBuilder.CreateTable(
                name: "Proceso",
                columns: table => new
                {
                    ClvProceso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcesoNombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proceso", x => x.ClvProceso);
                });

            migrationBuilder.CreateTable(
                name: "Proceso_Detalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClvObra = table.Column<int>(type: "int", nullable: false),
                    ClvViga = table.Column<int>(type: "int", nullable: false),
                    ClvProceso = table.Column<int>(type: "int", nullable: false),
                    FechaProcesoInicia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaProcesoSalida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumEmpleado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proceso_Detalle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    NumEmpleado = table.Column<int>(type: "int", nullable: false),
                    Contraseña = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Viga",
                columns: table => new
                {
                    ClvViga = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClvObra = table.Column<int>(type: "int", nullable: false),
                    LargoViga = table.Column<double>(type: "float", nullable: false),
                    PesoViga = table.Column<double>(type: "float", nullable: false),
                    Material = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    FechaViga = table.Column<DateTime>(type: "datetime", nullable: false),
                    NumEmpleado = table.Column<int>(type: "int", nullable: false),
                    ClvDefecto = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Viga__0277C515A9A9E17F", x => x.ClvViga);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Defectos");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Obra");

            migrationBuilder.DropTable(
                name: "Proceso");

            migrationBuilder.DropTable(
                name: "Proceso_Detalle");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Viga");
        }
    }
}
