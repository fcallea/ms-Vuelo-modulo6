using AeronlineaServicios.Api.Vuelos.Modelo.Aeronave;
using AeronlineaServicios.Api.Vuelos.Persistencia;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AeronlineaServicios.Api.Vuelos.Aplicacion
{
    public class NuevoGuardarAeronave
    {
        public class GuardarAeronaveCommand : IRequest<Guid>
        {
            public Guid AeronaveGuid { get; set; }
            public int NroAsientos { get; set; }
        }


        public class GuardarAeronaveHandler : IRequestHandler<GuardarAeronaveCommand, Guid>
        {
            public readonly ContextoVuelo _contexto;

            public GuardarAeronaveHandler(ContextoVuelo contexto)
            {
                _contexto = contexto;
            }

            public async Task<Guid> Handle(GuardarAeronaveCommand request, CancellationToken cancellationToken)
            {
                var aeronave = new Aeronave
                {
                    AeronaveGuid = request.AeronaveGuid,
                    NroAsientos = request.NroAsientos
                };

                _contexto.Aeronave.Add(aeronave);
                var valor = await _contexto.SaveChangesAsync();

                if (valor > 0)
                {
                    return aeronave.AeronaveGuid;
                }

                throw new Exception("No se pudo insertar la Tripulacion");
            }
        }
    }
}
