using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AerolineaServicios.Rabbitmq.Comandos;
using AerolineaServicios.Rabbitmq.Eventos;

namespace AerolineaServicios.Rabbitmq.BusRabbit
{
    public interface IRabbitEventBus
    {

        Task EnviarComando<T>(T comando) where T : Comando;
             
        void Publish<T>(T @evento) where T : Evento;
        void Subscribe<T, TH>() where T : Evento
                               where TH : IEventoManejador<T>;

    }
}
