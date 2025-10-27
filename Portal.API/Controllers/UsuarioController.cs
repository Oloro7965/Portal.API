using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.Commands.CreateUserCommand;
using Portal.Application.Commands.DeleteUserCommand;
using Portal.Application.Commands.UpdateUserCommand;
using Portal.Application.Commands.UpdateUserStatusCommand;
using Portal.Application.Queries.GetAllUsersQuery;
using Portal.Application.Queries.GetUsersQuery;
using Portal.Application.Queries.LoginQuery;


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
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginQuery query)
        {
            //command.Id =id;

            var result = await _mediator.Send(query);
            if (!result.IsSuccess)
            {
                return Unauthorized(new
                {
                    success = false,
                    message = result.Message,
                });
            }
            var token = result.Extra as string;
            if (token == null)
            {
                return BadRequest("Token não pode ser nulo");
            }
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None,
                Path = "/",
                Expires = DateTime.UtcNow.AddHours(2),
                IsEssential = true,
            };
            Response.Cookies.Append("AuthToken", token, cookieOptions);
            return Ok(new
            {
                success = true,
                message = result.Message,
                usuario = result.Data,
                token,
                tipoUsuario = result.Data?.TipoUsuario
            });
        }
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            if (Request.Cookies.ContainsKey("AuthToken"))
            {
                Response.Cookies.Delete("AuthToken");
            }
            await Task.CompletedTask;
            return Ok(new { message = "Logout realizado com sucesso" });
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
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateUserStatus(UpdateUserStatusCommand command)

        {
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok("Usuário atualizado para alunoNejusc com sucesso.");
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