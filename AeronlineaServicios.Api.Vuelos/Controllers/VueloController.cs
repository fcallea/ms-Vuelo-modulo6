using AeronlineaServicios.Api.Vuelos.Aplicacion;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AeronlineaServicios.Api.Vuelos.Controllers
{
    [Route("api/Vuelo")]
    [ApiController]
    public class VueloController : ControllerBase
    {
        private readonly IMediator _mediator;
        public VueloController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CrearDestinoVuelo(NuevoDestinoVuelo.CrearDestinoVueloCommand data)
        {
            return await _mediator.Send(data);
        }

        [HttpPost("AsignarVuelo")]
        public async Task<IActionResult> Create([FromBody] NuevoAsignacionVuelo.AsignarVueloCommand command)
        {
            Guid id = await _mediator.Send(command);

            if (id == Guid.Empty)
                return BadRequest();

            return Ok(id);
        }


        [HttpPost("GuardarTripulacion")]
        public async Task<IActionResult> GuardarTripulacion([FromBody] NuevoGuardarTripulacion.GuardarTripulacionCommand command)
        {
            Guid id = await _mediator.Send(command);

            if (id == Guid.Empty)
                return BadRequest();

            return Ok(id);
        }

        [HttpPost("GuardarAeropuerto")]
        public async Task<IActionResult> GuardarAeropuerto([FromBody] NuevoGuardarAeropuerto.GuardarAeropuertoCommand command)
        {
            Guid id = await _mediator.Send(command);

            if (id == Guid.Empty)
                return BadRequest();

            return Ok(id);
        }

        [HttpPost("GuardarAeronave")]
        public async Task<IActionResult> GuardarAeronave([FromBody] NuevoGuardarAeronave.GuardarAeronaveCommand command)
        {
            Guid id = await _mediator.Send(command);

            if (id == Guid.Empty)
                return BadRequest();

            return Ok(id);
        }

    }
}