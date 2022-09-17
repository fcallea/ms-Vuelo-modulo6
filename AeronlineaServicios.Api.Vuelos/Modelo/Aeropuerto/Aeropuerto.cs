using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AeronlineaServicios.Api.Vuelos.Modelo.Aeropuerto
{
    public class Aeropuerto
    {
        public int AeropuertoId { get; set; }
        public Guid IdAeropuerto { get; set; }

        [StringLength(120)]
        public string NombreAeropuerto { get; set; }

        [StringLength(4)]
        public string OACI { get; set; }

        [StringLength(3)]
        public string IATA { get; set; }
    }
}
