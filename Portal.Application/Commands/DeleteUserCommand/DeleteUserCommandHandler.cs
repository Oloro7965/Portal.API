using MediatR;
using Portal.Application.ViewModels;
using Portal.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Commands.DeleteUserCommand
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ResultViewModel>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public DeleteUserCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task<ResultViewModel> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _usuarioRepository.GetByIdAsync(request.Id);
            if (user == null)
            {
                return ResultViewModel.Error("Usuário não encontrado.");
            }
            user.Delete();
            await _usuarioRepository.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}
