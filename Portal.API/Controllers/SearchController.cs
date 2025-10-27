using MediatR;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.Queries.GetConteudoQuery;

namespace Portal.API.Controllers
{
    public class SearchController : Controller
    {
        private readonly IMediator _mediator;

        public SearchController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return BadRequest("A consulta não pode estar vazia.");

            // 🔹 Busca revistas
            var result = await _mediator.Send(new GetConteudoQuery(query));


            if (!result.Data.Any())
                return NotFound("Nenhum resultado encontrado para os termos informados.");

            // 🔹 Retorna tudo junto
            return Ok(new
            {
                Query = query,
                resultado= result
            });
        }
    }
}
