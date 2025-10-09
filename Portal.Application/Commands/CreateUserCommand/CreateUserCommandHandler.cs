using MediatR;
using Portal.Application.ViewModels;
using Portal.Core.Entities;
using Portal.Core.Repositories;
using Portal.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Commands.CreateUserCommand
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ResultViewModel<object>>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IAuthService _authService;

        public CreateUserCommandHandler(IUsuarioRepository usuarioRepository, IAuthService authService)
        {
            _usuarioRepository = usuarioRepository;
            _authService = authService;
        }

        public async Task<ResultViewModel<object>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var senhaHash = _authService.ComputeHash(request.senhaHash);
            var usuario = new Usuario(request.NomeCompleto, request.email, senhaHash,request.tipoUsuario);
            await _usuarioRepository.AddAsync(usuario);
            return ResultViewModel<object>.Success( new { usuario.Id});
        }
    }
}
