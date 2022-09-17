using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AerolineaServicios.Api.Aeropuertos.Modelo
{
    public class Aeropuerto
    {
        public int AeropuertoId { get; set; }
        public Guid IdAeropuerto { get; set; }
        [StringLength(100)]
        public string NombreAeropuerto { get; set; }

        [StringLength(4)]
        public string OACI { get; set; }

        [StringLength(3)]
        public string IATA { get; set; }

        [StringLength(120)]
        public string Pais { get; set; }

        [StringLength(120)]
        public string Departamento { get; set; }

        [StringLength(120)]
        public string Provincia { get; set; }

        [StringLength(120)]
        public string Localidad { get; set; }

        [StringLength(20)]
        public string EstadoAeropuerto { get; set; }
    }
}
