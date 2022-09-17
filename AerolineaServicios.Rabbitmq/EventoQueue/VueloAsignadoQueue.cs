using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AerolineaServicios.Rabbitmq.Eventos;

namespace AerolineaServicios.Rabbitmq.EventoQueue
{
    public class VueloAsignadoQueue : Evento
    {
        public Guid IdVuelo { get; set; }
        public Guid IdTripulacion { get; set; }
        public Guid IdAeronave { get; set; }

        public VueloAsignadoQueue(Guid idVuelo, Guid idTripulacion, Guid idAeronave)
        {
            IdVuelo = idVuelo;
            IdTripulacion = idTripulacion;
            IdAeronave = idAeronave;
        }
    }
}
