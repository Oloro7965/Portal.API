using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Portal.API.Controllers
{
    public class ArtigosController : Controller
    {
        private readonly IMediator _mediator;

        public ArtigosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllUsers()
        {

            var Query = new GetAllUsersQuery();

            var users = await _mediator.Send(Query);

            return Ok(users);
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

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommand command)
        {
            var UserId = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetUserById), new { id = UserId }, command);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsert(UpdateUserCommand command)
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
