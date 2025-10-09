using MediatR;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.Commands.CreateRevistaCommand;
using Portal.Application.Commands.DeleteRevistaCommand;
using Portal.Application.Commands.UpdateRevistaCommand;
using Portal.Application.Queries.GetAllRevistasQuery;
using Portal.Application.Queries.GetRevistaQuery;

namespace Portal.API.Controllers
{
    [ApiController]
    [Route("api/revista")]
    public class RevistaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RevistaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllRevistas()
        {
            var Query = new GetAllRevistasQuery();

            var revistas = await _mediator.Send(Query);

            return Ok(revistas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRevistaById(Guid id)
        {
            var query = new GetRevistaQuery(id);

            var revista = await _mediator.Send(query);

            if (!revista.IsSuccess)
            {
                return BadRequest(revista.Message);
            }

            return Ok(revista);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRevista(CreateRevistaCommand command)
        {
            var RevistaId = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetRevistaById), new { id = RevistaId }, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRevista(UpdateRevistaCommand command)
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
        public async Task<IActionResult> DeleteRevista(Guid id)
        {
            var command = new DeleteRevistaCommand(id);

            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok();
        }
    }
}
