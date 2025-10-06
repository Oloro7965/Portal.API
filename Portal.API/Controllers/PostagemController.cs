using MediatR;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.Commands.CreatePostagemCommand;
using Portal.Application.Commands.DeletePostagemCommand;
using Portal.Application.Commands.UpdatePostagemCommand;
using Portal.Application.Queries.GetAllPostagensQuery;
using Portal.Application.Queries.GetPostagemQuery;


namespace Portal.API.Controllers
{
    public class PostagemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostagemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllPostagens()
        {
            var Query = new GetAllPostagensQuery();

            var postagens = await _mediator.Send(Query);

            return Ok(postagens);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostagemById(Guid id)
        {
            var query = new GetPostagemQuery(id);

            var postagem = await _mediator.Send(query);

            if (!postagem.IsSuccess)
            {
                return BadRequest(postagem.Message);
            }

            return Ok(postagem);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePostagem(CreatePostagemCommand command)
        {
            var PostagemId = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetPostagemById), new { id = PostagemId }, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePostagem(UpdatePostagemCommand command)
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
        public async Task<IActionResult> DeletePostagem(Guid id)
        {
            var command = new DeletePostagemCommand(id);

            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok();
        }
    }
}
