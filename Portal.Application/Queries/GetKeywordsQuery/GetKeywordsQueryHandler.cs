using MediatR;
using Portal.Application.Queries.GetUsersQuery;
using Portal.Application.ViewModels;
using Portal.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Queries.GetKeywordsQuery
{
    public class GetKeywordsQueryHandler : IRequestHandler<GetKeywordsQuery, ResultViewModel<KeywordsViewModel>>
    {
        private readonly IKeywordsRepository _keywordsRepository;

        public GetKeywordsQueryHandler(IKeywordsRepository keywordsRepository)
        {
            _keywordsRepository = keywordsRepository;
        }

        public async Task<ResultViewModel<KeywordsViewModel>> Handle(GetKeywordsQuery request, CancellationToken cancellationToken)
        {
            var keyword = await _keywordsRepository.GetByIdAsync(request.Id);
            if (keyword is null)
            {
                return ResultViewModel<KeywordsViewModel>.Error("Usuário não encontrado.");
            }
            var KeywordDetailViewModel = new KeywordsViewModel(keyword.titulo);
            return ResultViewModel<KeywordsViewModel>.Success(KeywordDetailViewModel);
        }
    }
}
