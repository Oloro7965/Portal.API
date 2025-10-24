using MediatR;
using Portal.Application.Interfaces;
using Portal.Application.ViewModels;
using Portal.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Queries.GetArtigosSemanticosQuery
{
    public class GetArtigosSemanticosQueryHandler : IRequestHandler<GetArtigosSemanticosQuery, ResultViewModel<List<PublicacaoViewModel>>>
    {
        private readonly IArtigoRepository _artigoRepository;
        private readonly IRevistaRepository _revistaRepository;
        private readonly IEmbeddingService _embeddingService;
        public Task<ResultViewModel<List<PublicacaoViewModel>>> Handle(GetArtigosSemanticosQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
