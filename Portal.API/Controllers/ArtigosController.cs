using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.Commands.CreateArtigoCommand;
using Portal.Application.Commands.DeleteArtigoCommand;
using Portal.Application.Commands.UpdateArtigoCommand;
using Portal.Application.Commands.UploadPdfArtigoCommand;
using Portal.Application.Queries.DownloadArtigoQuery;
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

        // 📘 Público
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllArtigos()
        {
            var query = new GetAllArtigosQuery();
            var artigos = await _mediator.Send(query);
            return Ok(artigos);
        }

        // 📘 Público
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetArtigoById(Guid id)
        {
            var query = new GetArtigoQuery(id);
            var artigo = await _mediator.Send(query);

            if (!artigo.IsSuccess)
                return BadRequest(artigo.Message);

            return Ok(artigo);
        }
        [HttpGet("{id}/download",Name = "DownloadPdfArtigo")]
        public async Task<IActionResult> DownloadPdfArtigo(Guid id)
        {
            var query= new DownloadArtigoQuery(id);
            var bytes = await _mediator.Send(query);

            return File(bytes, "application/pdf", $"artigo-{id}.pdf");
        }
        // ✏️ Somente professor ou admin
        [HttpPost]
        [Authorize(Roles = "professor,admin")]
        public async Task<IActionResult> CreateArtigo(CreateArtigoCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetArtigoById), new { id = result.Data }, new
            {
                id = result.Data,
                success = true,
                message = "Artigo criado com sucesso",
            });
        }

        // ✏️ Somente professor ou admin
        [HttpPut("{id}")]
        [Authorize(Roles = "professor,admin")]
        public async Task<IActionResult> UpdateArtigo(UpdateArtigoCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return NoContent();
        }
        [HttpPut("{id}/upload")]
        public async Task<IActionResult> UploadPdf(UploadPdfArtigoCommand command)
        {
            if (command.ArquivoPdf == null || command.ArquivoPdf.Length == 0)
                return BadRequest("Arquivo inválido");

            await _mediator.Send(command);

            return Ok("Upload concluído com sucesso");
        }
        // 🗑️ Somente professor ou admin
        [HttpDelete("{id}")]
        [Authorize(Roles = "professor,admin")]
        public async Task<IActionResult> DeleteArtigo(Guid id)
        {
            var command = new DeleteArtigoCommand(id);
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok();
        }
    }
}
