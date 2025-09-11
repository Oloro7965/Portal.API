using MediatR;
using Portal.Application.ViewModels;
using Portal.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Commands.UpdateUserCommand
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ResultViewModel>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UpdateUserCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task<ResultViewModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(request.id);
            if (usuario == null)
            {
                return ResultViewModel.Error("Usuário não encontrado.");
            }
            usuario.Update(request.Email, request.PasswordHash);
            await _usuarioRepository.SaveChangesAsync();
            return ResultViewModel.Success();
        }
    }
}
