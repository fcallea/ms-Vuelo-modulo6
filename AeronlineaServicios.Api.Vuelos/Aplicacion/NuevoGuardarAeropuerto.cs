using AeronlineaServicios.Api.Vuelos.Modelo.Aeropuerto;
using AeronlineaServicios.Api.Vuelos.Persistencia;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AeronlineaServicios.Api.Vuelos.Aplicacion
{
    public class NuevoGuardarAeropuerto
    {
        public class GuardarAeropuertoCommand : IRequest<Guid>
        {
            public Guid IdAeropuerto { get; set; }
            public string NombreAeropuerto { get; set; }
            public string OACI { get; set; }
            public string IATA { get; set; }
        }

        public class GuardarAeropuertoHandler : IRequestHandler<GuardarAeropuertoCommand, Guid>
        {
            public readonly ContextoVuelo _contexto;

            public GuardarAeropuertoHandler(ContextoVuelo contexto)
            {
                _contexto = contexto;
            }

            public async Task<Guid> Handle(GuardarAeropuertoCommand request, CancellationToken cancellationToken)
            {
                var aeropuerto = new Aeropuerto
                {
                    IdAeropuerto = request.IdAeropuerto,
                    NombreAeropuerto = request.NombreAeropuerto,
                    OACI = request.OACI,
                    IATA = request.IATA
                };

                _contexto.Aeropuerto.Add(aeropuerto);
                var valor = await _contexto.SaveChangesAsync();

                if (valor > 0)
                {
                    return aeropuerto.IdAeropuerto;
                }

                throw new Exception("No se pudo insertar el Aeropuerto");
            }
        }
    }
}
