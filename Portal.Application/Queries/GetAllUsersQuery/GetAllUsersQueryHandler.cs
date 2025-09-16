using MediatR;
using Portal.Application.ViewModels;
using Portal.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Queries.GetAllUsersQuery
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, ResultViewModel<List<UsuarioViewModel>>>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public GetAllUsersQueryHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task<ResultViewModel<List<UsuarioViewModel>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var usuarios = await _usuarioRepository.GetAllAsync();
            var usuarioViewModel = usuarios.Select(u => new UsuarioViewModel(u.NomeCompleto, u.email, u.artigos, u.postagens, u.comentarios, u.tipoUsuario, u.RevistasPublicadas)).ToList();
            return ResultViewModel<List<UsuarioViewModel>>.Success(usuarioViewModel);
        }
    }
}
