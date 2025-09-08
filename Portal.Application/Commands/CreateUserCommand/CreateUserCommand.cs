using Portal.Core.Entities;
using Portal.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Commands.CreateUserCommand
{
    public class CreateUserCommand
    {
        public string NomeCompleto { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public List<artigo> artigos { get; set; }
        public List<Postagem> postagens { get; set; }
        public List<Comentario> comentarios { get; set; }
        public EtipoUsuario tipoUsuario { get; set; }
        public List<Revista> RevistasPublicadas { get; set; }
    }
}
