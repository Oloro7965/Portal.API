using MediatR;
using Portal.Core.Repositories;
using Portal.Application.ViewModels;
using Portal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Commands.CreateComentarioCommand
{
    public class CreateComentarioCommandHandler : IRequestHandler<CreateComentarioCommand, ResultViewModel<object>>
    {
        private readonly IComentarioRepository _comentarioRepository;
        public CreateComentarioCommandHandler(IComentarioRepository comentarioRepository) { 
            _comentarioRepository = comentarioRepository;

        }

    public async Task<ResultViewModel<object>> Handle(CreateComentarioCommand request, CancellationToken cancellationToken)
        {
            var comentario = new Comentario(request.Conteudo);
            await _comentarioRepository.AddAsync(comentario);
            return ResultViewModel<object>.Success(new { comentario.Id });

        }

    }
}
