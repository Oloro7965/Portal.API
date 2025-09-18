using MediatR;
using Portal.Application.ViewModels;
using Portal.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Commands.UpdatePostagemCommand
{
    public class UpdatePostagemCommandHandler : IRequestHandler<UpdatePostagemCommand, ResultViewModel>
    {
        private readonly IPostagemRepository _postagemRepository;
        public UpdatePostagemCommandHandler(IPostagemRepository postagemRepository)
        {
            _postagemRepository = postagemRepository;
        }
        public async Task<ResultViewModel> Handle(UpdatePostagemCommand request, CancellationToken cancellationToken)
        {
            var postagem = await _postagemRepository.GetByIdAsync(request.Id);
            if (postagem == null)
            {
                return ResultViewModel.Error("Postagem não encontrada.");
            }
            postagem.Update(request.Conteudo, request.Comentarios);
            await _postagemRepository.SaveChangesAsync();
            return ResultViewModel.Success();
        }
    }
}
