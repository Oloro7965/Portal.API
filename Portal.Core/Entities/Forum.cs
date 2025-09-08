using Portal.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Core.Entities
{
    public class Forum:BaseEntity
    {
        public Forum(string titulo, Earea area, string descricao)
        {
            this.titulo = titulo;
            this.area = area;
            this.descricao = descricao;
        }

        public Forum(string titulo, Earea area, string descricao, List<postagem> postagem)
        {
            this.titulo = titulo;
            this.area = area;
            this.descricao = descricao;
            this.postagem = postagem;
        }

        public string titulo { get; private set; }
        public Earea area { get; private set; }
        public string descricao { get; private set; }
        public List<Postagem> postagem { get; private set; }
    }
}
