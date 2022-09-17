using AeronlineaServicios.Api.Vuelos.Modelo.Tripulacion;
using AeronlineaServicios.Api.Vuelos.Persistencia;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AeronlineaServicios.Api.Vuelos.Aplicacion
{
    public class NuevoGuardarTripulacion
    {
        public class GuardarTripulacionCommand : IRequest<Guid>
        {
            public string TripGuid { get; set; }
            public string EstadoTrip { get; set; }
        }


        public class GuardarTripulacionHandler : IRequestHandler<GuardarTripulacionCommand, Guid>
        {
            public readonly ContextoVuelo _contexto;

            public GuardarTripulacionHandler(ContextoVuelo contexto)
            {
                _contexto = contexto;
            }

            public async Task<Guid> Handle(GuardarTripulacionCommand request, CancellationToken cancellationToken)
            {
                var tripulacion = new Tripulacion
                {
                    IdTripulacion = Guid.Parse(request.TripGuid),
                    EstadoTripulcion = request.EstadoTrip
                };

                _contexto.Tripulacion.Add(tripulacion);
                var valor = await _contexto.SaveChangesAsync();

                if (valor > 0)
                {
                    return tripulacion.IdTripulacion;
                }

                throw new Exception("No se pudo insertar el Tripulacion");
            }
        }
    }
}
