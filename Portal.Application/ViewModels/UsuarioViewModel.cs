using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.ViewModels
{
    public class UsuarioViewModel
    {
        public string NomeCompleto { get; private set; }
        public string email { get; private set; }
        public List<artigo> artigos { get; private set; }
        public List<postagem> postagens { get; private set; }
        public List<comentario> comentarios { get; private set; }
        public EtipoUsuario tipoUsuario { get; private set; }
        public List<Revista> RevistasPublicadas { get; private set; }
    }
}
