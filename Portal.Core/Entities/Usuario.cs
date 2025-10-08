using Portal.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Core.Entities
{
    public class Usuario:BaseEntity
    {
        public Usuario(string nomeCompleto, string email, string senhaHash, EtipoUsuario tipoUsuario)
        {
            NomeCompleto = nomeCompleto;
            this.email = email;
            this.senhaHash = senhaHash;
            this.artigos = new List<artigo>();
            this.postagens = new List<Postagem>();
            this.comentarios = new List<Comentario>();
            this.tipoUsuario = tipoUsuario;
            RevistasPublicadas = new List<Revista>();
        }

        public string NomeCompleto { get; private set; }
        public string email { get; private set; }
        public string senhaHash { get; private set; }
        public List<artigo> artigos { get; private set; }
        public List<Postagem> postagens { get; private set; }
        public List<Comentario> comentarios { get; private set; }
        public EtipoUsuario tipoUsuario { get; private set; }
        public List<Evento> EventosComoPalestrante { get; private set; }
        public List<Revista> RevistasPublicadas { get; private set; }

        public bool IsDeleted { get; private set; }
        public void Delete()
        {
            IsDeleted = true;
        }
        public void Update(string Email, string password)
        {
            email = Email;

            senhaHash = password;

        }

    }
}
