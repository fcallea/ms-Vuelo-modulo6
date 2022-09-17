using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AerolineaServicios.Api.Aeropuertos.Aplicacion
{
    public class AeropuertoDto
    {
        public string NombreAeropuerto { get; set; }
        public string OACI { get; set; }
        public string IATA { get; set; }
        public string Pais { get; set; }
        public string Departamento { get; set; }
        public string Provincia { get; set; }
        public string Localidad { get; set; }
        public string EstadoAeropuerto { get; set; }
    }
}
