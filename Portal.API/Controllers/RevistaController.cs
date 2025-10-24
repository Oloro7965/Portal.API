using MediatR;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllRevistas()
        {
            var query = new GetAllRevistasQuery();
            var revistas = await _mediator.Send(query);
            return Ok(revistas);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetRevistaById(Guid id)
        {
            var query = new GetRevistaQuery(id);
            var revista = await _mediator.Send(query);

            if (!revista.IsSuccess)
                return BadRequest(revista.Message);

            return Ok(revista);
        }

        [HttpPost]
        [Authorize(Roles = "professor,admin")]
        public async Task<IActionResult> CreateRevista(CreateRevistaCommand command)
        {
            var revistaId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetRevistaById), new { id = revistaId }, command);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "professor,admin")]
        public async Task<IActionResult> UpdateRevista(UpdateRevistaCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "professor,admin")]
        public async Task<IActionResult> DeleteRevista(Guid id)
        {
            var command = new DeleteRevistaCommand(id);
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok();
        }
    }
}
