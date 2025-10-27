using MediatR;
using Portal.Application.ViewModels;
using Portal.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Commands.UpdateUserStatusCommand
{
    public class UpdateUserStatusCommandHandler : IRequestHandler<UpdateUserStatusCommand, ResultViewModel>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UpdateUserStatusCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<ResultViewModel> Handle(UpdateUserStatusCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(request.Id);
            if (usuario == null)
            {
                return ResultViewModel.Error("Usuário não encontrado.");
            }
            usuario.TornarAlunoNejusc();
            await _usuarioRepository.SaveChangesAsync();
            return ResultViewModel.Success();
        }
    }
}
