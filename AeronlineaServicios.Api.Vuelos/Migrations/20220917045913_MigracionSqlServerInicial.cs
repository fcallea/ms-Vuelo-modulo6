using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AeronlineaServicios.Api.Vuelos.Migrations
{
    public partial class MigracionSqlServerInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aeronave",
                columns: table => new
                {
                    AeronaveId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AeronaveGuid = table.Column<Guid>(nullable: false),
                    NroAsientos = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aeronave", x => x.AeronaveId);
                });

            migrationBuilder.CreateTable(
                name: "Aeropuerto",
                columns: table => new
                {
                    AeropuertoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAeropuerto = table.Column<Guid>(nullable: false),
                    NombreAeropuerto = table.Column<string>(maxLength: 120, nullable: true),
                    OACI = table.Column<string>(maxLength: 4, nullable: true),
                    IATA = table.Column<string>(maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aeropuerto", x => x.AeropuertoId);
                });

            migrationBuilder.CreateTable(
                name: "Tripulacion",
                columns: table => new
                {
                    TripulacionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTripulacion = table.Column<Guid>(nullable: false),
                    EstadoTripulcion = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tripulacion", x => x.TripulacionId);
                });

            migrationBuilder.CreateTable(
                name: "Vuelo",
                columns: table => new
                {
                    VueloId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdVuelo = table.Column<Guid>(nullable: false),
                    IdAeropuertoOrigen = table.Column<Guid>(nullable: false),
                    IdAeropuertoDestino = table.Column<Guid>(nullable: false),
                    NroVuelo = table.Column<int>(nullable: false),
                    EstadoVuelo = table.Column<string>(maxLength: 20, nullable: true),
                    MillasVuelo = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    FechaHoraAlta = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vuelo", x => x.VueloId);
                });

            migrationBuilder.CreateTable(
                name: "ItinerarioVuelo",
                columns: table => new
                {
                    ItinerarioVueloId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VueloId = table.Column<int>(nullable: false),
                    IdItinerarioVuelo = table.Column<Guid>(nullable: false),
                    IdVuelo = table.Column<Guid>(nullable: false),
                    IdTripulacion = table.Column<Guid>(nullable: false),
                    IdAeronave = table.Column<Guid>(nullable: false),
                    FechaHoraCreacion = table.Column<DateTime>(type: "DateTime", nullable: false),
                    ZonaAbordaje = table.Column<string>(maxLength: 20, nullable: true),
                    NroPuertaAbordaje = table.Column<string>(maxLength: 20, nullable: true),
                    FechaHoraAbordaje = table.Column<DateTime>(type: "DateTime", nullable: false),
                    FechaHoraPartida = table.Column<DateTime>(type: "DateTime", nullable: false),
                    FechaHoraLLegada = table.Column<DateTime>(type: "DateTime", nullable: false),
                    NroAsientosHabilitados = table.Column<int>(nullable: false),
                    NroAsientosDisponibles = table.Column<int>(nullable: false),
                    TipoVuelo = table.Column<string>(maxLength: 20, nullable: true),
                    EstadoItinerarioVuelo = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItinerarioVuelo", x => x.ItinerarioVueloId);
                    table.ForeignKey(
                        name: "FK_ItinerarioVuelo_Vuelo_VueloId",
                        column: x => x.VueloId,
                        principalTable: "Vuelo",
                        principalColumn: "VueloId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItinerarioVuelo_VueloId",
                table: "ItinerarioVuelo",
                column: "VueloId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aeronave");

            migrationBuilder.DropTable(
                name: "Aeropuerto");

            migrationBuilder.DropTable(
                name: "ItinerarioVuelo");

            migrationBuilder.DropTable(
                name: "Tripulacion");

            migrationBuilder.DropTable(
                name: "Vuelo");
        }
    }
}
