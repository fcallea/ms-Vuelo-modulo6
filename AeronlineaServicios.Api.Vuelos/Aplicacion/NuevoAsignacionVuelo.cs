using AeronlineaServicios.Api.Vuelos.Modelo;
using AeronlineaServicios.Api.Vuelos.Persistencia;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AerolineaServicios.Rabbitmq.BusRabbit;
using AerolineaServicios.Rabbitmq.EventoQueue;

namespace AeronlineaServicios.Api.Vuelos.Aplicacion
{
    public class NuevoAsignacionVuelo
    {
        public class AsignarVueloCommand : IRequest<Guid>
        {
            public Guid IdVuelo { get; set; }
            public List<ItinerarioVueloDto> ListaItinerarios { get; set; }
            public AsignarVueloCommand() { }

            public AsignarVueloCommand(List<ItinerarioVueloDto> lista)
            {
                ListaItinerarios = lista;
            }

        }

        public class EjecutaValidacionCrearDestinoVuelo : AbstractValidator<AsignarVueloCommand>
        {
            public EjecutaValidacionCrearDestinoVuelo()
            {
                RuleFor(x => x.IdVuelo).NotEmpty();
            }
        }
        public class AsignarVueloHandler : IRequestHandler<AsignarVueloCommand, Guid>
        {
            public readonly ContextoVuelo _contexto;
            private readonly IRabbitEventBus _eventBus;

            public AsignarVueloHandler(ContextoVuelo contexto, IRabbitEventBus eventBus)
            {
                _contexto = contexto;
                _eventBus = eventBus;
            }

            public async Task<Guid> Handle(AsignarVueloCommand request, CancellationToken cancellationToken)
            {
                var vuelo = await _contexto.Vuelo.FirstOrDefaultAsync(x => x.IdVuelo == request.IdVuelo);

                if(vuelo == null)
                {
                    throw new Exception("Errores en identificar ID Vuelo");
                }

                Guid idVuelo = vuelo.IdVuelo;
                int id = vuelo.VueloId;

                foreach (var obj in request.ListaItinerarios)
                {
                    var itinerario = new ItinerarioVuelo
                    {
                        VueloId = id,
                        IdVuelo = idVuelo,
                        IdItinerarioVuelo = Guid.NewGuid(),
                        IdTripulacion = obj.IdTripulacion,
                        IdAeronave = obj.IdAeronave,
                        FechaHoraCreacion = DateTime.Now,
                        ZonaAbordaje = obj.ZonaAbordaje,
                        NroPuertaAbordaje = obj.NroPuertaAbordaje,
                        FechaHoraAbordaje = obj.FechaHoraAbordaje,
                        FechaHoraPartida = obj.FechaHoraPartida,
                        FechaHoraLLegada = DateTime.Now,
                        NroAsientosHabilitados = obj.NroAsientosHabilitados,
                        NroAsientosDisponibles = obj.NroAsientosHabilitados,
                        TipoVuelo = obj.TipoVuelo,
                        EstadoItinerarioVuelo = "A"
                    };

                    _contexto.ItinerarioVuelo.Add(itinerario);

                    _eventBus.Publish(new VueloAsignadoTripulacionQueue(itinerario.IdVuelo, itinerario.IdTripulacion, itinerario.IdAeronave)); 
                    _eventBus.Publish(new VueloAsignadoAeronaveQueue(itinerario.IdVuelo, itinerario.IdTripulacion, itinerario.IdAeronave)); 
                    _eventBus.Publish(new VueloAsignadoReservaQueue(itinerario.IdVuelo, itinerario.IdTripulacion, itinerario.IdAeronave)); 

                }

                var valor = await _contexto.SaveChangesAsync();


                if (valor > 0)
                {
                    return vuelo.IdVuelo;
                }

                throw new Exception("No se pudo insertar el Vuelo");
            }


        }
    }
}
