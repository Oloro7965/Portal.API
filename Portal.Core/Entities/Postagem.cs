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

        public Postagem(string conteudo, List<Comentario> comentarios)
        {
            this.conteudo = conteudo;
            this.comentarios = comentarios;
        }
    }
}
