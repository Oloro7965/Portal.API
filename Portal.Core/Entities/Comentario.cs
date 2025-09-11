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
        public bool IsDeleted { get; private set; }
        public void Delete()
        {
            IsDeleted = true;
        }
        public void Update(string Conteudo)
        {
            conteudo = Conteudo;
        }
    }
}
