using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Core.Entities
{
    public class Keywords:BaseEntity
    {
       public Keywords(string titulo)
        {
            this.titulo = titulo;
            artigos = new List<artigo>();
        }
        public string titulo { get; private set; }
        public List<artigo> artigos { get; private set; }
    }
}
