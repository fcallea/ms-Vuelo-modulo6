using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AeronlineaServicios.Api.Vuelos.Aplicacion
{
    public class ItinerarioVueloDto
    {
        public Guid IdTripulacion { get; set; }
        public Guid IdAeronave { get; set; }
        public string ZonaAbordaje { get; set; }
        public string NroPuertaAbordaje { get; set; }
        public DateTime FechaHoraAbordaje { get; set; }
        public DateTime FechaHoraPartida { get; set; }
        public int NroAsientosHabilitados { get; set; }
        public string TipoVuelo { get; set; }
    }
}
