using Microsoft.AspNetCore.Mvc;

namespace Portal.API.Controllers
{
    public class UsuarioController : ControllerBase
    {
        [HttpGet()]
        public async Task<IActionResult> GetAllUsers()
        {

            //var Query = new GetAllUsersQuery();

            //var users = await _mediator.Send(Query);

            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            //var query = new GetUserQuery(id);

            //var user = await _mediator.Send(query);

            //if (!user.IsSuccess)
            {
                //return BadRequest(user.Message);
            }

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser()
        {
            //var UserId = await _mediator.Send(command);

            //return CreatedAtAction(nameof(GetUserById), new { id = UserId }, command);

            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser()

        {
            //command.Id =id;

            return Ok();
        }
    }

}
