using MediatR;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.Commands.CreateKeywordCommand;
using Portal.Application.Commands.CreateUserCommand;
using Portal.Application.Commands.DeleteKeywordCommand;
using Portal.Application.Commands.DeleteUserCommand;
using Portal.Application.Commands.UpdateKeywordCommand;
using Portal.Application.Commands.UpdateUserCommand;
using Portal.Application.Queries.GetAllKeywordsQuery;
using Portal.Application.Queries.GetKeywordsQuery;

namespace Portal.API.Controllers
{
    [ApiController]
    [Route("api/keyword")]
    public class KeywordController : ControllerBase
    {
        private readonly IMediator _mediator;

        public KeywordController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllKeywords()
        {

            var Query = new GetAllKeywordsQuery();

            var users = await _mediator.Send(Query);

            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetKeywordById(int id)
        {
            var query = new GetKeywordsQuery(id);

            var keyword = await _mediator.Send(query);

            if (!keyword.IsSuccess)
            {
                return BadRequest(keyword.Message);
            }

            return Ok(keyword);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateKeywordCommand command)
        {
            var UserId = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetKeywordById), new { id = UserId }, command);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateKeyword(UpdateKeywordCommand command)
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
        public async Task<IActionResult> DeleteKeyword(int id)
        {
            var command = new DeleteKeywordCommand(id);

            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            //_userService.Delete(id);
            return Ok();
        }
    }
}
