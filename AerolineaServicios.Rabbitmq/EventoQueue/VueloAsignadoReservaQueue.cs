using AerolineaServicios.Rabbitmq.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AerolineaServicios.Rabbitmq.EventoQueue
{
    public class VueloAsignadoReservaQueue: Evento
    {
        public Guid VueloGuid{ get; set; }
        public Guid TripulacionGuid { get; set; }
        public Guid AeronaveGuid { get; set; }

        public VueloAsignadoReservaQueue(Guid vueloGuid, Guid tripulacionGuid, Guid aeronaveGuid)
        {
            VueloGuid = vueloGuid;
            TripulacionGuid = tripulacionGuid;
            AeronaveGuid = aeronaveGuid;
        }
    }
}
