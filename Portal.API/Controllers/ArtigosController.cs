using MediatR;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.Commands.CreateArtigoCommand;
using Portal.Application.Commands.DeleteArtigoCommand;
using Portal.Application.Commands.UpdateArtigoCommand;
using Portal.Application.Queries.GetAllArtigosQuery;
using Portal.Application.Queries.GetArtigoQuery;

namespace Portal.API.Controllers
{   
[ApiController]
[Route("api/artigos")]
    public class ArtigosController : Controller
    {
        private readonly IMediator _mediator;

        public ArtigosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllArtigos()
        {
            var Query = new GetAllArtigosQuery();

            var artigos = await _mediator.Send(Query);

            return Ok(artigos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArtigoById(Guid id)
        {
            var query = new GetArtigoQuery(id);

            var artigo = await _mediator.Send(query);

            if (!artigo.IsSuccess)
            {
                return BadRequest(artigo.Message);
            }

            return Ok(artigo);
        }

        [HttpPost]
        public async Task<IActionResult> CreateArtigo(CreateArtigoCommand command)
        {
            var ArtigoId = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetArtigoById), new { id = ArtigoId }, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArtigo(UpdateArtigoCommand command)
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
        public async Task<IActionResult> DeleteArtigo(Guid id)
        {
            var command = new DeleteArtigoCommand(id);

            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok();
        }
    }
}
