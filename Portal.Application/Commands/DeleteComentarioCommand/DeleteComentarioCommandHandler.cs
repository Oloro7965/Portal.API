using MediatR;
using Portal.Application.ViewModels;
using Portal.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Commands.DeleteComentarioCommand
{
    public class DeleteComentarioCommandHandler : ResultViewModel, IRequestHandler<DeleteComentarioCommand, ResultViewModel>
    {
        private readonly IComentarioRepository _comentarioRepository;
        public DeleteComentarioCommandHandler(IComentarioRepository comentarioRepository)
        {
            _comentarioRepository = comentarioRepository;
        }

        public async Task<ResultViewModel> Handle(DeleteComentarioCommand request, CancellationToken cancellationToken)
        {
            var comentario = await _comentarioRepository.GetByIdAsync(request.Id);
            if (comentario == null)
            {
                return ResultViewModel.Error("Nenhum comentário encontrado.");
            }
            comentario.Delete();
            await _comentarioRepository.SaveChangesAsync();
            return ResultViewModel.Success();
        }
    }
}
