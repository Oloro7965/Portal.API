using MediatR;
using Portal.Application.Interfaces;
using Portal.Application.ViewModels;
using Portal.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Queries.GetArtigoQuery
{
    public class GetArtigoQueryHandler : IRequestHandler<GetArtigoQuery, ResultViewModel<ArtigoViewModel>>
    {
        private readonly IArtigoRepository _artigoRepository;
        private readonly IUrlGenerator _urlGenerator;

        public GetArtigoQueryHandler(IArtigoRepository artigoRepository, IUrlGenerator urlGenerator)
        {
            _artigoRepository = artigoRepository;
            _urlGenerator = urlGenerator;
        }

        public async Task<ResultViewModel<ArtigoViewModel>> Handle(GetArtigoQuery request, CancellationToken cancellationToken)
        {
            var artigo = await _artigoRepository.GetByIdAsync(request.Id);
            if (artigo is null)
            {
                return ResultViewModel<ArtigoViewModel>.Error("Este artigo não existe");
            }

            var ArtigoDetailViewModel = new ArtigoViewModel(artigo.Id,artigo.titulo, artigo.descricao, 
                artigo.publicacao, artigo.autores, artigo.area, artigo.keywords, 
                artigo.arquivopdf != null ? _urlGenerator.GetDownloadArtigoUrl(artigo.Id) : null);
            return ResultViewModel<ArtigoViewModel>.Success(ArtigoDetailViewModel);
        }
    }
}
