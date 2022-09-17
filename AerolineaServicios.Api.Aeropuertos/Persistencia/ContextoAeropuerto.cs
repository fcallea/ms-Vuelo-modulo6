using AerolineaServicios.Api.Aeropuertos.Modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AerolineaServicios.Api.Aeropuertos.Persistencia
{
    public class ContextoAeropuerto: DbContext
    {
        public ContextoAeropuerto(DbContextOptions<ContextoAeropuerto> options) : base(options) { }
        public DbSet<Aeropuerto> Aeropuerto { get; set; }
    }
}
