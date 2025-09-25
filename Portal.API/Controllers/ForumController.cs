using MediatR;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.Commands.CreateForumCommand;
using Portal.Application.Commands.DeleteForumCommand;
using Portal.Application.Commands.UpdateForumCommand;
using Portal.Application.Queries.GetAllForumsQuery;
using Portal.Application.Queries.GetForumQuery;

namespace Portal.API.Controllers
{
    public class ForumController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ForumController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllForuns()
        {
            var Query = new GetAllForumsQuery();

            var foruns = await _mediator.Send(Query);

            return Ok(foruns);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetForumById(Guid id)
        {
            var query = new GetForumQuery(id);

            var forum = await _mediator.Send(query);

            if (!forum.IsSuccess)
            {
                return BadRequest(forum.Message);
            }

            return Ok(forum);
        }

        [HttpPost]
        public async Task<IActionResult> CreateForum(CreateForumCommand command)
        {
            var ForumId = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetForumById), new { id = ForumId }, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateForum(UpdateForumCommand command)
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
        public async Task<IActionResult> DeleteForum(Guid id)
        {
            var command = new DeleteForumCommand(id);

            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok();
        }
    }
}
