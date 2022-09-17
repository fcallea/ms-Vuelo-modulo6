using AerolineaServicios.Api.Aeropuertos.Aplicacion;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AerolineaServicios.Api.Aeropuertos.Controllers
{
    [Route("api/Aeropuerto")]
    [ApiController]
    public class AeropuertoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AeropuertoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CrearAeropuerto(NuevoAeropuerto.CrearAeropuertoCommand data)
        {
            return await _mediator.Send(data);
        }
    }
}
