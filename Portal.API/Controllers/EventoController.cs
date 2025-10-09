using MediatR;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.Commands.CreateEventCommand;
using Portal.Application.Commands.DeleteEventCommand;
using Portal.Application.Commands.UpdateEventCommand;
using Portal.Application.Queries.GetAllEventosQuery;
using Portal.Application.Queries.GetEventoQuery;

namespace Portal.API.Controllers
{
    [ApiController]
    [Route("api/evento")]
    public class EventoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllEventos()
        {
            var Query = new GetAllEventosQuery();

            var eventos = await _mediator.Send(Query);

            return Ok(eventos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventoById(Guid id)
        {
            var query = new GetEventoQuery(id);

            var evento = await _mediator.Send(query);

            if (!evento.IsSuccess)
            {
                return BadRequest(evento.Message);
            }

            return Ok(evento);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvento(CreateEventCommand command)
        {
            var EventoId = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetEventoById), new { id = EventoId }, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvento(UpdateEventCommand command)
        {
            //command.Id =id;

            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvento(Guid id)
        {
            var command = new DeleteEventCommand(id);

            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok();
        }
    }
}
