using MediatR;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.Commands.CreateUserCommand;
using Portal.Application.Commands.DeleteUserCommand;
using Portal.Application.Commands.UpdateUserCommand;
using Portal.Application.Queries.GetAllUsersQuery;
using Portal.Application.Queries.GetUsersQuery;


namespace Portal.API.Controllers
{
    [ApiController]
    [Route("api/usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllUsers()
        {

            var Query = new GetAllUsersQuery();

            var users = await _mediator.Send(Query);

            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var query = new GetUserQuery(id);

            var user = await _mediator.Send(query);

            if (!user.IsSuccess)
            {
                return BadRequest(user.Message);
            }

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommand command)
        {
            var UserId = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetUserById), new { id = UserId }, command);

            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(UpdateUserCommand command)

        {
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var command = new DeleteUserCommand(id);

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
