using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AeronlineaServicios.Api.Vuelos.Modelo.Tripulacion
{
    public class Tripulacion
    {
        public int TripulacionId { get; set; }
        public Guid IdTripulacion { get; set; }

        [StringLength(20)]
        public string EstadoTripulcion { get; set; }
    }
}
