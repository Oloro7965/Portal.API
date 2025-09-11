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
        public Usuario(string nomeCompleto, string email, string senha, List<artigo> artigos, List<postagem> postagens, List<comentario> comentarios, EtipoUsuario tipoUsuario, List<Revista> revistasPublicadas)
        {
            NomeCompleto = nomeCompleto;
            this.email = email;
            this.senha = senha;
            this.artigos = artigos;
            this.postagens = postagens;
            this.comentarios = comentarios;
            this.tipoUsuario = tipoUsuario;
            RevistasPublicadas = revistasPublicadas;
        }

        public string NomeCompleto { get; private set; }
        public string email { get; private set; }
        public string senha { get; private set; }
        public List<artigo> artigos { get; private set; }
        public List<Postagem> postagens { get; private set; }
        public List<Comentario> comentarios { get; private set; }
        public EtipoUsuario tipoUsuario { get; private set; }
        public List<Revista> RevistasPublicadas { get; private set; }
        public bool IsDeleted { get; private set; }
        public void Delete()
        {
            IsDeleted = true;
        }
        public void Update(string Email, string password)
        {
            email = Email;

            senha = password;

        }

    }
}
