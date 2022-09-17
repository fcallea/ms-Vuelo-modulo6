using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AerolineaServicios.Api.Aeropuertos.Migrations
{
    public partial class MigracionSqlServerInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aeropuerto",
                columns: table => new
                {
                    AeropuertoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAeropuerto = table.Column<Guid>(nullable: false),
                    NombreAeropuerto = table.Column<string>(maxLength: 100, nullable: true),
                    OACI = table.Column<string>(maxLength: 4, nullable: true),
                    IATA = table.Column<string>(maxLength: 3, nullable: true),
                    Pais = table.Column<string>(maxLength: 120, nullable: true),
                    Departamento = table.Column<string>(maxLength: 120, nullable: true),
                    Provincia = table.Column<string>(maxLength: 120, nullable: true),
                    Localidad = table.Column<string>(maxLength: 120, nullable: true),
                    EstadoAeropuerto = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aeropuerto", x => x.AeropuertoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aeropuerto");
        }
    }
}
