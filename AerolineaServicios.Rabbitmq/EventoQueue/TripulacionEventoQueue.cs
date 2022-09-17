using AerolineaServicios.Rabbitmq.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AerolineaServicios.Rabbitmq.EventoQueue
{
    public class TripulacionEventoQueue : Evento
    {
        public string TripGuid { get; set; }
        public string TripId { get; set; }
        public string NombreTripulacion { get; set; }
        public string EstadoTrip { get; set; }

        public TripulacionEventoQueue(string tripGuid, string tripId, string nombreTripulacion, string estadoTrip)
        {
            TripGuid = tripGuid;
            TripId = tripId;
            NombreTripulacion = nombreTripulacion;
            EstadoTrip = estadoTrip;
        }
    }


}
