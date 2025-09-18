using MediatR;
using Portal.Application.ViewModels;
using Portal.Core.Entities;
using Portal.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Commands.CreateUserCommand
{
    public class CreateUserCommand : IRequest<ResultViewModel<object>>
    {
        public string NomeCompleto { get; set; }
        public string email { get; set; }
        public string senhaHash { get; set; }
        public List<artigo> artigos { get; set; }
        public List<Postagem> postagens { get; set; }
        public List<Comentario> comentarios { get; set; }
        public EtipoUsuario tipoUsuario { get; set; }
        public List<Revista> RevistasPublicadas { get; set; }
    }
}
