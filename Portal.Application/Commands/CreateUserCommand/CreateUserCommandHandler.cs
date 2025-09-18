using MediatR;
using Portal.Application.ViewModels;
using Portal.Core.Entities;
using Portal.Core.Repositories;
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
        public CreateUserCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task<ResultViewModel<object>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var usuario = new Usuario(request.NomeCompleto, request.email, request.senhaHash, request.artigos, request.postagens, request.comentarios, request.tipoUsuario, request.RevistasPublicadas);
            await _usuarioRepository.AddAsync(usuario);
            return ResultViewModel<object>.Success( new { usuario.Id});
        }
    }
}
