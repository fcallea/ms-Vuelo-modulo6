using AerolineaServicios.Rabbitmq.BusRabbit;
using AerolineaServicios.Rabbitmq.EventoQueue;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AeronlineaServicios.Api.Vuelos.ManajadorRabbit
{
    public class EmailEventoManejador : IEventoManejador<EmailEventoQueue>
    {
        //private readonly ILogger<EmailEventoManejador> _logger;  
        public EmailEventoManejador() { }
        //public EmailEventoManejador(ILogger<EmailEventoManejador> loggers)
        //{
        //    _logger = loggers;
        //}
        public Task Handle(EmailEventoQueue @evento)
        {
            //_logger.LogInformation($"Valor Cola {evento.Titulo}");
            return Task.CompletedTask;
        }
    }
}
