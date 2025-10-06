using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Core.Entities
{
    public class Postagem:BaseEntity
    {
        public string conteudo { get; private set; }
        public List<Comentario> comentarios { get; private set; }
        public Guid IdUsuario { get; private set; }
        public Usuario usuario { get; private set; }

        public Postagem(string conteudo)
        {
            this.conteudo = conteudo;
            this.comentarios = new List<Comentario>();
        }
        public bool IsDeleted { get; private set; }
        public void Delete()
        {
            IsDeleted = true;
        }
        public void Update(string Conteudo, List<Comentario> Comentario)
        {
            conteudo = Conteudo;
            comentarios = Comentario;
        }
    }
}
