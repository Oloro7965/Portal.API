using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.Commands.CreateRevistaCommand;
using Portal.Application.Commands.DeleteRevistaCommand;
using Portal.Application.Commands.UpdateRevistaCommand;
using Portal.Application.Commands.UploadImagemCommand;
using Portal.Application.Commands.UploadPdfArtigoCommand;
using Portal.Application.Commands.UploadPdfRevistaCommand;
using Portal.Application.Queries.BaixarRevistaQuery;
using Portal.Application.Queries.DownloadArtigoQuery;
using Portal.Application.Queries.DownloadCapaRevistaQuery;
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
        [HttpGet("{id}/download",Name = "DownloadPdfRevista")]
        public async Task<IActionResult> DownloadPdfRevista(Guid id)
        {
            var query = new DownloadRevistaQuery(id);
            var bytes = await _mediator.Send(query);

            return File(bytes, "application/pdf", $"revista-{id}.pdf");
        }
        [HttpGet("{id}/downloadImagem", Name = "DownloadImagemRevista")]
        public async Task<IActionResult> DownloadImagemRevista(Guid id)
        {
            var query = new DownloadCapaRevistaQuery(id);
            var bytes = await _mediator.Send(query);
            if (bytes is null || bytes.Length == 0)
                return NotFound("Capa não encontrada.");
            return File(bytes, "image/jpeg");
        }
        [HttpPost]
        [Authorize(Roles = "professor,admin")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreateRevista([FromForm] CreateRevistaCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetRevistaById), new { id = result.Data }, new
            {
                id = result.Data,
                success = true,
                message = "Revista criada com sucesso",
            });
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
        [HttpPut("{id}/upload")]
        public async Task<IActionResult> UploadPdf(UploadPdfRevistaCommand command)
        {
            if (command.ArquivoPdf == null || command.ArquivoPdf.Length == 0)
                return BadRequest("Arquivo inválido");

            await _mediator.Send(command);

            return Ok("Upload concluído com sucesso");
        }
        [HttpPut("{id}/imagem")]
        public async Task<IActionResult> UploadImagem(UploadImagemCommand command)
        {
            if (command.Capa == null || command.Capa.Length == 0)
                return BadRequest("Arquivo inválido");

            await _mediator.Send(command);

            return Ok("Upload de imagem concluído com sucesso");
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
