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
        public UsuarioViewModel(string nomeCompleto, string email, string? senhaHash=null, List<artigo>? artigos=null, List<Postagem>? postagens = null, 
            List<Comentario>? comentarios=null, EtipoUsuario? tipoUsuario= null, List<Revista>? revistasPublicadas= null)
        {
            NomeCompleto = nomeCompleto;
            this.email = email;
            this.senhaHash = senhaHash;
            this.artigos = artigos;
            this.postagens = postagens;
            this.comentarios = comentarios;
            this.tipoUsuario = tipoUsuario;
            this.RevistasPublicadas = revistasPublicadas;
        }

        public string NomeCompleto { get; private set; }
        public string email { get; private set; }
        public string? senhaHash { get; private set; }
        public List<artigo>? artigos { get; private set; }
        public List<Postagem>? postagens { get; private set; }
        public List<Comentario>? comentarios { get; private set; }
        public EtipoUsuario? tipoUsuario { get; private set; }
        public List<Revista>? RevistasPublicadas { get; private set; }
    }
}
