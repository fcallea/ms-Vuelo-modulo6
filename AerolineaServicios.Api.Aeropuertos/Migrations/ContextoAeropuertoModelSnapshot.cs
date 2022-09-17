﻿// <auto-generated />
using System;
using AerolineaServicios.Api.Aeropuertos.Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AerolineaServicios.Api.Aeropuertos.Migrations
{
    [DbContext(typeof(ContextoAeropuerto))]
    partial class ContextoAeropuertoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AerolineaServicios.Api.Aeropuertos.Modelo.Aeropuerto", b =>
                {
                    b.Property<int>("AeropuertoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Departamento")
                        .HasColumnType("nvarchar(120)")
                        .HasMaxLength(120);

                    b.Property<string>("EstadoAeropuerto")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("IATA")
                        .HasColumnType("nvarchar(3)")
                        .HasMaxLength(3);

                    b.Property<Guid>("IdAeropuerto")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Localidad")
                        .HasColumnType("nvarchar(120)")
                        .HasMaxLength(120);

                    b.Property<string>("NombreAeropuerto")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("OACI")
                        .HasColumnType("nvarchar(4)")
                        .HasMaxLength(4);

                    b.Property<string>("Pais")
                        .HasColumnType("nvarchar(120)")
                        .HasMaxLength(120);

                    b.Property<string>("Provincia")
                        .HasColumnType("nvarchar(120)")
                        .HasMaxLength(120);

                    b.HasKey("AeropuertoId");

                    b.ToTable("Aeropuerto");
                });
#pragma warning restore 612, 618
        }
    }
}