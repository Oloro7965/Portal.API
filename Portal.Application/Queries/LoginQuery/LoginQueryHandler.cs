using MediatR;
using Portal.Application.ViewModels;
using Portal.Core.Repositories;
using Portal.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Queries.LoginQuery
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ResultViewModel<LoginViewModel>>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IAuthService _authService;

        public LoginQueryHandler(IUsuarioRepository usuarioRepository, IAuthService authService)
        {
            _usuarioRepository = usuarioRepository;
            _authService = authService;
        }

        public async Task<ResultViewModel<LoginViewModel>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.GetByEmailAsync(request.Email);
            if (usuario == null)
                return ResultViewModel<LoginViewModel>.Error("CPF não encontrado ou inválido");

            // Valida a senha usando o AuthService
            var senhaHash = _authService.ComputeHash(request.Senha);
            if (usuario.senhaHash != senhaHash)
                throw new UnauthorizedAccessException("Credenciais inválidas");

            // Gera token JWT com papel do usuário
            var token = _authService.GenerateToken(usuario.Id.ToString(), usuario.email, usuario.tipoUsuario);

            var login = new LoginViewModel(usuario.Id.ToString(), usuario.NomeCompleto, usuario.email, usuario.tipoUsuario.ToString());

            return ResultViewModel<LoginViewModel>.Success(login, "Login realizado com sucesso.", token);
        }
    }
}
