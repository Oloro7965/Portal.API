using MediatR;
using Portal.Core.Repositories;
using Portal.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Commands.DeletePostagemCommand
{
    public class DeletePostagemCommandHandler : IRequestHandler<DeletePostagemCommand, ResultViewModel>
    {
        private readonly IPostagemRepository _postagemRepository;
        public DeletePostagemCommandHandler(IPostagemRepository postagemRepository)
        {
            _postagemRepository = postagemRepository;
        }
        public async Task<ResultViewModel> Handle(DeletePostagemCommand request, CancellationToken cancellationToken)
        {
            var postagem = await _postagemRepository.GetByIdAsync(request.Id);
            if (postagem == null)
            {
                return ResultViewModel.Error("Nenhuma postagem encontrada.");
            }
            postagem.Delete();
            await _postagemRepository.SaveChangesAsync();
            return ResultViewModel.Success();
        }
    }
}
