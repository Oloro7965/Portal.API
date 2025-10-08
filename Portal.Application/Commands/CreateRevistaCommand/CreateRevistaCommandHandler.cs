using MediatR;
using Portal.Core.Entities;
using Portal.Core.Repositories;
using Portal.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Commands.CreateRevistaCommand
{
    public class CreateRevistaCommandHandler : IRequestHandler<CreateRevistaCommand, ResultViewModel<object>>   
    {
        private readonly IRevistaRepository _revistaRepository;

        public CreateRevistaCommandHandler(IRevistaRepository revistaRepository)
        {
            _revistaRepository = revistaRepository;
        }
        public async Task<ResultViewModel<object>> Handle(CreateRevistaCommand request, CancellationToken CancellationToken) 
        {
            var revista = new Revista(
                request.titulo,
                request.descricao,
                request.edicao,
                request.capa,
                request.publicacao,
                request.arquivopdf,
                request.area
                
            );
            await _revistaRepository.AddAsync(revista);
            return ResultViewModel<object>.Success(new { revista.Id });
        }
    }
}
