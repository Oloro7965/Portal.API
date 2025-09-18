using MediatR;
using Portal.Application.ViewModels;
using Portal.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Queries.GetUsersQuery
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, ResultViewModel<UsuarioViewModel>>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public GetUserQueryHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task<ResultViewModel<UsuarioViewModel>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(request.Id);
            if (usuario is null)
            {
                return ResultViewModel<UsuarioViewModel>.Error("Usuário não encontrado.");
            }
            var UsuarioDetailViewModel = new UsuarioViewModel(usuario.NomeCompleto, usuario.email, usuario.senhaHash, usuario.artigos, usuario.postagens, usuario.comentarios, usuario.tipoUsuario, usuario.RevistasPublicadas);
            return ResultViewModel<UsuarioViewModel>.Success(UsuarioDetailViewModel);
        }
    }
}
