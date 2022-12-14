// <auto-generated />
using System;
using AeronlineaServicios.Api.Vuelos.Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AeronlineaServicios.Api.Vuelos.Migrations
{
    [DbContext(typeof(ContextoVuelo))]
    [Migration("20220917045913_MigracionSqlServerInicial")]
    partial class MigracionSqlServerInicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AeronlineaServicios.Api.Vuelos.Modelo.Aeronave.Aeronave", b =>
                {
                    b.Property<int>("AeronaveId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("AeronaveGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("NroAsientos")
                        .HasColumnType("int");

                    b.HasKey("AeronaveId");

                    b.ToTable("Aeronave");
                });

            modelBuilder.Entity("AeronlineaServicios.Api.Vuelos.Modelo.Aeropuerto.Aeropuerto", b =>
                {
                    b.Property<int>("AeropuertoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("IATA")
                        .HasColumnType("nvarchar(3)")
                        .HasMaxLength(3);

                    b.Property<Guid>("IdAeropuerto")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NombreAeropuerto")
                        .HasColumnType("nvarchar(120)")
                        .HasMaxLength(120);

                    b.Property<string>("OACI")
                        .HasColumnType("nvarchar(4)")
                        .HasMaxLength(4);

                    b.HasKey("AeropuertoId");

                    b.ToTable("Aeropuerto");
                });

            modelBuilder.Entity("AeronlineaServicios.Api.Vuelos.Modelo.ItinerarioVuelo", b =>
                {
                    b.Property<int>("ItinerarioVueloId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EstadoItinerarioVuelo")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<DateTime>("FechaHoraAbordaje")
                        .HasColumnType("DateTime");

                    b.Property<DateTime>("FechaHoraCreacion")
                        .HasColumnType("DateTime");

                    b.Property<DateTime>("FechaHoraLLegada")
                        .HasColumnType("DateTime");

                    b.Property<DateTime>("FechaHoraPartida")
                        .HasColumnType("DateTime");

                    b.Property<Guid>("IdAeronave")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdItinerarioVuelo")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdTripulacion")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdVuelo")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("NroAsientosDisponibles")
                        .HasColumnType("int");

                    b.Property<int>("NroAsientosHabilitados")
                        .HasColumnType("int");

                    b.Property<string>("NroPuertaAbordaje")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("TipoVuelo")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<int>("VueloId")
                        .HasColumnType("int");

                    b.Property<string>("ZonaAbordaje")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("ItinerarioVueloId");

                    b.HasIndex("VueloId");

                    b.ToTable("ItinerarioVuelo");
                });

            modelBuilder.Entity("AeronlineaServicios.Api.Vuelos.Modelo.Tripulacion.Tripulacion", b =>
                {
                    b.Property<int>("TripulacionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EstadoTripulcion")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<Guid>("IdTripulacion")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TripulacionId");

                    b.ToTable("Tripulacion");
                });

            modelBuilder.Entity("AeronlineaServicios.Api.Vuelos.Modelo.Vuelo", b =>
                {
                    b.Property<int>("VueloId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EstadoVuelo")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<DateTime>("FechaHoraAlta")
                        .HasColumnType("DateTime");

                    b.Property<Guid>("IdAeropuertoDestino")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdAeropuertoOrigen")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdVuelo")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("MillasVuelo")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("NroVuelo")
                        .HasColumnType("int");

                    b.HasKey("VueloId");

                    b.ToTable("Vuelo");
                });

            modelBuilder.Entity("AeronlineaServicios.Api.Vuelos.Modelo.ItinerarioVuelo", b =>
                {
                    b.HasOne("AeronlineaServicios.Api.Vuelos.Modelo.Vuelo", "Vuelo")
                        .WithMany("ListaItinerario")
                        .HasForeignKey("VueloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
