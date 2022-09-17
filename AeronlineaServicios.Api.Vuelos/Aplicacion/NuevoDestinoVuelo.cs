using AeronlineaServicios.Api.Vuelos.Modelo;
using AeronlineaServicios.Api.Vuelos.Persistencia;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AeronlineaServicios.Api.Vuelos
{
    public class NuevoDestinoVuelo
    {
        public class CrearDestinoVueloCommand : IRequest<Guid>
        {
            public Guid IdAeropuertoOrigen { get; set; }
            public Guid IdAeropuertoDestino { get; set; }
        }

        public class EjecutaValidacionCrearDestinoVuelo : AbstractValidator<CrearDestinoVueloCommand>
        {
            public EjecutaValidacionCrearDestinoVuelo()
            {
                RuleFor(x => x.IdAeropuertoOrigen).NotEmpty();
                RuleFor(x => x.IdAeropuertoDestino).NotEmpty();
            }
        }
        public class CrearDestinoVueloHandler : IRequestHandler<CrearDestinoVueloCommand, Guid>
        {
            public readonly ContextoVuelo _contexto;

            public CrearDestinoVueloHandler(ContextoVuelo contexto)
            {
                _contexto = contexto;
            }

            public async Task<Guid> Handle(CrearDestinoVueloCommand request, CancellationToken cancellationToken)
            {
                var vuelo = new Vuelo
                {
                    IdVuelo = Guid.NewGuid(),
                    IdAeropuertoOrigen = request.IdAeropuertoOrigen,
                    IdAeropuertoDestino = request.IdAeropuertoDestino,
                    NroVuelo = 101,
                    EstadoVuelo = "A",
                    MillasVuelo = 0,
                    FechaHoraAlta = DateTime.Now
                };

                _contexto.Vuelo.Add(vuelo);
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