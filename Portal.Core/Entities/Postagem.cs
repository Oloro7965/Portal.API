using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Core.Entities
{
    public class postagem:BaseEntity
    {
        public string conteudo { get; private set; }
        public List<comentario> comentarios { get; private set; }

        public postagem(List<comentario> comentarios)
        {
            this.comentarios = comentarios;
        }
    }
}
