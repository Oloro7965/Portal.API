using MediatR;
using Portal.Application.Interfaces;
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
        private readonly IUrlGenerator _urlGenerator;

        public GetRevistaQueryHandler(IRevistaRepository revistaRepository, IUrlGenerator urlGenerator)
        {
            _revistaRepository = revistaRepository;
            _urlGenerator = urlGenerator;
        }

        public async Task<ResultViewModel<RevistaViewModel>> Handle(GetRevistaQuery request, CancellationToken cancellationToken)
        {
            var revista = await _revistaRepository.GetByIdAsync(request.Id);
            if (revista is null)
            {
                return ResultViewModel<RevistaViewModel>.Error("Revista não encontrada.");
            }
            var RevistaDetailViewModel = new RevistaViewModel(revista.Id, revista.titulo, revista.descricao, 
                revista.publicacao,revista.autores, 
                revista.area, revista.keywords, revista.IsDeleted,revista.capa != null ? _urlGenerator.GetImagemRevistaUrl(revista.Id) : null,
                revista.arquivopdf != null ? _urlGenerator.GetDownloadRevistaUrl(revista.Id) : null);
            return ResultViewModel<RevistaViewModel>.Success(RevistaDetailViewModel);
        }
    }
}
