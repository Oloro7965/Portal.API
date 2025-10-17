using MediatR;
using Portal.Application.ViewModels;
using Portal.Core.Entities;
using Portal.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Commands.CreateKeywordCommand
{
    public class CreateKeywordCommandHandler : IRequestHandler<CreateKeywordCommand, ResultViewModel<object>>
    {
        private readonly IKeywordsRepository _keywordsRepository;

        public CreateKeywordCommandHandler(IKeywordsRepository keywordsRepository)
        {
            _keywordsRepository = keywordsRepository;
        }

        public async Task<ResultViewModel<object>> Handle(CreateKeywordCommand request, CancellationToken cancellationToken)
        {
            var keyword = new Keywords(
                request.titulo
            );

            await _keywordsRepository.AddAsync(keyword);
            return ResultViewModel<object>.Success(new { keyword.Id });
        }
    }
}
