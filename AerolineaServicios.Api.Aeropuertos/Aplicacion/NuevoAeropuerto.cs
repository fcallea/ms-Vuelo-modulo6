using AerolineaServicios.Api.Aeropuertos.Modelo;
using AerolineaServicios.Api.Aeropuertos.Persistencia;
using AerolineaServicios.Rabbitmq.BusRabbit;
using AerolineaServicios.Rabbitmq.EventoQueue;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AerolineaServicios.Api.Aeropuertos.Aplicacion
{
    public class NuevoAeropuerto
    {
        public class CrearAeropuertoCommand : IRequest<Guid>
        {
            public AeropuertoDto Aeropuerto { get; set; }
            public CrearAeropuertoCommand()
            {
                Aeropuerto = new AeropuertoDto();
            }
        }

        public class EjecutaValidacionCrearAeropuerto : AbstractValidator<CrearAeropuertoCommand>
        {
            public EjecutaValidacionCrearAeropuerto()
            {
                RuleFor(x => x.Aeropuerto.NombreAeropuerto).NotEmpty();
                RuleFor(x => x.Aeropuerto.OACI).NotEmpty();
            }
        }
        public class CrearAeropuertoHandler : IRequestHandler<CrearAeropuertoCommand, Guid>
        {
            public readonly ContextoAeropuerto _contexto;
            private readonly IRabbitEventBus _eventBus;

            public CrearAeropuertoHandler(ContextoAeropuerto contexto, IRabbitEventBus eventBus)
            {
                _contexto = contexto;
                _eventBus = eventBus;
            }

            public async Task<Guid> Handle(CrearAeropuertoCommand request, CancellationToken cancellationToken)
            {
                var aeropuerto = new Aeropuerto
                {
                    IdAeropuerto = Guid.NewGuid(),
                    NombreAeropuerto = request.Aeropuerto.NombreAeropuerto,
                    OACI = request.Aeropuerto.OACI,
                    IATA = request.Aeropuerto.IATA,
                    Pais = request.Aeropuerto.Pais,
                    Departamento = request.Aeropuerto.Departamento,
                    Provincia = request.Aeropuerto.Provincia,
                    Localidad = request.Aeropuerto.Localidad,
                    EstadoAeropuerto = "A"
                };


                _contexto.Aeropuerto.Add(aeropuerto);

                var valor = await _contexto.SaveChangesAsync();

                _eventBus.Publish(new AeropuertoCreadoQueue(aeropuerto.IdAeropuerto,aeropuerto.NombreAeropuerto, aeropuerto.OACI, aeropuerto.IATA , aeropuerto.Localidad, aeropuerto.EstadoAeropuerto)); ///"rcerruto@bancosol.com.bo", request.TripulacionNombre, "Se creo la tripulacion"));

                if (valor > 0)
                {
                    return aeropuerto.IdAeropuerto;
                }

                throw new Exception("No se pudo insertar el Vuelo");
            }

        }
    }
}
