using MediatR;
using Portal.Application.ViewModels;
using Portal.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Queries.GetRevistaQuery
{
    public class GetRevistaQueryHandler : IRequestHandler<GetRevistaQuery, ResultViewModel<RevistaViewModel>>
    {
        private readonly IRevistaRepository _revistaRepository;
        public GetRevistaQueryHandler(IRevistaRepository revistaRepository)
        {
            _revistaRepository = revistaRepository;
        }
        public async Task<ResultViewModel<RevistaViewModel>> Handle(GetRevistaQuery request, CancellationToken cancellationToken)
        {
            var revista = await _revistaRepository.GetByIdAsync(request.Id);
            if (revista is null)
            {
                return ResultViewModel<RevistaViewModel>.Error("Revista não encontrada.");
            }
            var RevistaDetailViewModel = new RevistaViewModel(revista.titulo, revista.descricao, revista.edicao, revista.capa, revista.publicacao, revista.arquivopdf, revista.autores, revista.area, revista.keywords, revista.IsDeleted);
            return ResultViewModel<RevistaViewModel>.Success(RevistaDetailViewModel);
        }
    }
}
