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

        public CreateArtigoCommandHandler(IArtigoRepository artigoRepository, 
            IKeywordsRepository keywordsRepository, IArquivoArtigoService arquivoArtigoService)
        {
            _artigoRepository = artigoRepository;
            _keywordsRepository = keywordsRepository;
            _arquivoArtigoService = arquivoArtigoService;
        }

        public async Task<ResultViewModel<object>> Handle(CreateArtigoCommand request, CancellationToken cancellationToken)
        {
            List<Keywords>? keywords = null;

            if (request.KeywordsIds is not null && request.KeywordsIds.Any())
            {
                keywords = await _keywordsRepository.GetByIdsAsync(request.KeywordsIds);
            }
            var artigo = new artigo(
                request.Titulo,
                request.Descricao,
                request.DataPublicacao,
                request.area,
                keywords
            );

            await _artigoRepository.AddAsync(artigo);
            if (request.Arquivopdf != null)
                await _arquivoArtigoService.UploadAsync(artigo.Id, request.Arquivopdf);
            return ResultViewModel<object>.Success(new { artigo.Id });
        }

    }
}
