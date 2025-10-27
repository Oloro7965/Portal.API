using MediatR;
using Portal.Application.ViewModels;
using Portal.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Queries.GetAllRevistasQuery
{
    public class GetAllRevistasQueryHandler : IRequestHandler<GetAllRevistasQuery, ResultViewModel<List<RevistaViewModel>>>
    {
        private readonly IRevistaRepository _revistaRepository;
        public GetAllRevistasQueryHandler(IRevistaRepository revistaRepository)
        {
            _revistaRepository = revistaRepository;
        }
        public async Task<ResultViewModel<List<RevistaViewModel>>> Handle(GetAllRevistasQuery request, CancellationToken cancellationToken)
        {
            var revistas = await _revistaRepository.GetAllAsync();
            var revistaViewModel = revistas.Select(r => new RevistaViewModel(r.titulo, r.descricao,r.edicao, r.publicacao, r.autores, r.area,r.keywords, r.IsDeleted)).ToList();
            return ResultViewModel<List<RevistaViewModel>>.Success(revistaViewModel);
        }
    }
}
