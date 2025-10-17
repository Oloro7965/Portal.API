using MediatR;
using Portal.Core.Entities;
using Portal.Core.Repositories;
using Portal.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portal.Core.Enums;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Portal.Application.Commands.CreateRevistaCommand
{
    public class CreateRevistaCommandHandler : IRequestHandler<CreateRevistaCommand, ResultViewModel<object>>   
    {
        private readonly IRevistaRepository _revistaRepository;
        private readonly IKeywordsRepository _keywordsRepository;

        public CreateRevistaCommandHandler(IRevistaRepository revistaRepository, IKeywordsRepository keywordsRepository)
        {
            _revistaRepository = revistaRepository;
            _keywordsRepository = keywordsRepository;
        }
        public async Task<ResultViewModel<object>> Handle(CreateRevistaCommand request, CancellationToken CancellationToken) 
        {
            List<Keywords>? keywords = null;

            if (request.KeywordsIds is not null && request.KeywordsIds.Any())
            {
                keywords = await _keywordsRepository.GetByIdsAsync(request.KeywordsIds);
            }
            var revista = new Revista(
                request.titulo,
                request.descricao,
                request.edicao,
                request.capa,
                request.publicacao,
                request.area
                
            );
            await _revistaRepository.AddAsync(revista);
            return ResultViewModel<object>.Success(new { revista.Id });
        }
    }
}
