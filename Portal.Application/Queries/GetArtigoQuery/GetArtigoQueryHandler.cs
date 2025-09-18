using MediatR;
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
        public GetArtigoQueryHandler(IArtigoRepository artigoRepository)
        {
            _artigoRepository = artigoRepository;
        }
        public async Task<ResultViewModel<ArtigoViewModel>> Handle(GetArtigoQuery request, CancellationToken cancellationToken)
        {
            var artigo = await _artigoRepository.GetByIdAsync(request.Id);
            if (artigo is null)
            {
                return ResultViewModel<ArtigoViewModel>.Error("Este artigo não existe");
            }

            var ArtigoDetailViewModel = new ArtigoViewModel(artigo.titulo, artigo.descricao, artigo.publicacao, artigo.arquivopdf, artigo.autores, artigo.area, artigo.keywords);
            return ResultViewModel<ArtigoViewModel>.Success(ArtigoDetailViewModel);
        }
    }
}
