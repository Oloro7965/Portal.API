using MediatR;
using Portal.Application.ViewModels;
using Portal.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Queries.GetAllKeywordsQuery
{
    public class GetAllKeywordsQueryHandler : IRequestHandler<GetAllKeywordsQuery, ResultViewModel<List<KeywordsViewModel>>>
    {
        private readonly IKeywordsRepository _keywordsRepository;

        public GetAllKeywordsQueryHandler(IKeywordsRepository keywordsRepository)
        {
            _keywordsRepository = keywordsRepository;
        }

        public async Task<ResultViewModel<List<KeywordsViewModel>>> Handle(GetAllKeywordsQuery request, CancellationToken cancellationToken)
        {
            var keywords = await _keywordsRepository.GetAllAsync();
            var keywordsViewModel = keywords.Select(u => new KeywordsViewModel(u.titulo)).ToList();
            return ResultViewModel<List<KeywordsViewModel>>.Success(keywordsViewModel);
        }
    }
}
