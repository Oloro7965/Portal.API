using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Core.Entities
{
    public class Comentario:BaseEntity
    {
        public Comentario(string conteudo)
        {
            this.conteudo = conteudo;
        }

        public string conteudo { get; private set; }
    }
}
