using AeronlineaServicios.Api.Vuelos.Modelo;
using AeronlineaServicios.Api.Vuelos.Modelo.Aeronave;
using AeronlineaServicios.Api.Vuelos.Modelo.Aeropuerto;
using AeronlineaServicios.Api.Vuelos.Modelo.Tripulacion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AeronlineaServicios.Api.Vuelos.Persistencia
{
    public class ContextoVuelo : DbContext
    {
        public ContextoVuelo(DbContextOptions<ContextoVuelo> options) : base(options) { }
        public DbSet<Vuelo> Vuelo { get; set; }
        public DbSet<ItinerarioVuelo> ItinerarioVuelo { get; set; }
        public DbSet<Tripulacion> Tripulacion { get; set; }
        public DbSet<Aeropuerto> Aeropuerto { get; set; }
        public DbSet<Aeronave> Aeronave { get; set; }
    }
}
