using MediatR;
using Portal.Core.Repositories;
using Portal.Application.ViewModels;
using Portal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portal.Core.Service;

namespace Portal.Application.Commands.CreateArtigoCommand
{
    public class CreateArtigoCommandHandler : IRequestHandler<CreateArtigoCommand, ResultViewModel<object>>
    {
        private readonly IArtigoRepository _artigoRepository;
        private readonly IKeywordsRepository _keywordsRepository;
        private readonly IArquivoArtigoService _arquivoArtigoService;
        private readonly IUsuarioRepository _usuarioRepository;

        public CreateArtigoCommandHandler(IArtigoRepository artigoRepository, IKeywordsRepository keywordsRepository,
            IArquivoArtigoService arquivoArtigoService, IUsuarioRepository usuarioRepository)
        {
            _artigoRepository = artigoRepository;
            _keywordsRepository = keywordsRepository;
            _arquivoArtigoService = arquivoArtigoService;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<ResultViewModel<object>> Handle(CreateArtigoCommand request, CancellationToken cancellationToken)
        {
            List<Keywords>? keywords = null;
            List<Usuario>? autores = null;
            if (request.KeywordsNames is not null && request.KeywordsNames.Any())
            {
                keywords = await _keywordsRepository.GetByNamesAsync(request.KeywordsNames);
            }
            if (request.Autores is not null && request.Autores.Any())
            {
                autores = await _usuarioRepository.GetByNamesAsync(request.Autores);
            }
            using var memoryStream = new MemoryStream();
            await request.Arquivopdf.CopyToAsync(memoryStream);
            var pdfBytes = memoryStream.ToArray();
            var artigo = new artigo(
                request.Titulo,
                request.Descricao,
                request.DataPublicacao,
                request.area,
                pdfBytes,
                keywords,
                autores
            );

            await _artigoRepository.AddAsync(artigo);
            if (request.Arquivopdf != null)
                await _arquivoArtigoService.UploadAsync(artigo.Id, request.Arquivopdf);
            return ResultViewModel<object>.Success(new { artigo.Id });
        }

    }
}
