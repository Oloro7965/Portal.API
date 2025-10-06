using MediatR;
using Portal.Core.Entities;
using Portal.Core.Repositories;
using Portal.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Commands.CreatePostagemCommand
{
    public class CreatePostagemCommandHandler : IRequestHandler<CreatePostagemCommand, ResultViewModel<object>>
    {
        private readonly IPostagemRepository _postagemRepository;
        public CreatePostagemCommandHandler(IPostagemRepository postagemRepository)
        {
            _postagemRepository = postagemRepository;
        }
        public async Task<ResultViewModel<object>> Handle(CreatePostagemCommand request, CancellationToken CancellationToken)
        {
            var postagem = new Postagem(request.conteudo);
            await _postagemRepository.AddAsync(postagem);
            return ResultViewModel<object>.Success(new { postagem.Id });
        }
    }
}
