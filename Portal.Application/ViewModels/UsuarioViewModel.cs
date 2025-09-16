using Portal.Core.Entities;
using Portal.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.ViewModels
{
    public class UsuarioViewModel
    {
        public UsuarioViewModel(string nomeCompleto, string email, List<artigo> artigos, List<Postagem> postagens, 
            List<Comentario> comentarios, EtipoUsuario tipoUsuario, List<Revista> revistasPublicadas)
        {
            NomeCompleto = nomeCompleto;
            this.email = email;
            this.artigos = artigos;
            this.postagens = postagens;
            this.comentarios = comentarios;
            this.tipoUsuario = tipoUsuario;
            RevistasPublicadas = revistasPublicadas;
        }

        public string NomeCompleto { get; private set; }
        public string email { get; private set; }
        public List<artigo> artigos { get; private set; }
        public List<Postagem> postagens { get; private set; }
        public List<Comentario> comentarios { get; private set; }
        public EtipoUsuario tipoUsuario { get; private set; }
        public List<Revista> RevistasPublicadas { get; private set; }
    }
}
