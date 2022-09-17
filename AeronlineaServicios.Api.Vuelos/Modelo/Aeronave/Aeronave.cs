using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AeronlineaServicios.Api.Vuelos.Modelo.Aeronave
{
    public class Aeronave
    {
        public int AeronaveId { get; set; }
        public Guid AeronaveGuid { get; set; }
        public int NroAsientos { get; set; }
    }
}
