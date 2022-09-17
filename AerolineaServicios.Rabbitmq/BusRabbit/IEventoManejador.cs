using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AerolineaServicios.Rabbitmq.Eventos;

namespace AerolineaServicios.Rabbitmq.BusRabbit
{
    public interface IEventoManejador<in TEvent>: IEventoManejador where TEvent: Evento
    {
        Task Handle(TEvent @evento);
    }
    public interface IEventoManejador
    {


    }
}
