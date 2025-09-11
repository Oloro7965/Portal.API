using MediatR;
using Portal.Application.ViewModels;
using Portal.Core.Repositories;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Commands.UpdateComentarioCommand
{
    public class UpdateComentarioCommandHandler : IRequestHandler<UpdateComentarioCommand, ResultViewModel>
    {
        private readonly IComentarioRepository _comentarioRepository;
        public UpdateComentarioCommandHandler(IComentarioRepository comentarioRepository)
        {
            _comentarioRepository = comentarioRepository;
        }
        public async Task<ResultViewModel> Handle(UpdateComentarioCommand request, CancellationToken cancellationToken)
        {
            var comentario = await _comentarioRepository.GetByIdAsync(request.Id);
            if (comentario == null)
            {
                return ResultViewModel.Error("Nenhum comentário encontrado.");
            }
            comentario.Update(request.Conteudo);
            await _comentarioRepository.SaveChangesAsync();
            return ResultViewModel.Success();
        }
    }
}
