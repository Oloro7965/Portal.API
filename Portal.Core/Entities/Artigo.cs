using Portal.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Core.Entities
{
    public class artigo:BaseEntity
    {
        public artigo(string titulo, string descricao, DateTime publicacao, string arquivopdf, List<Usuario> autores, Earea area, List<Keywords> keywords)
        {
            this.titulo = titulo;
            this.descricao = descricao;
            this.publicacao = publicacao;
            this.arquivopdf = arquivopdf;
            this.autores = autores;
            this.area = area;
            this.keywords = keywords;
        }

        public string titulo { get; private set; }
        public string descricao { get; private set; }
        public DateTime publicacao { get; private set; }
        public string arquivopdf { get; private set; }
        public List<Usuario> autores { get; private set; }
        public Earea area { get; private set; }
        public List<Keywords> keywords  { get; private set; }
    }
}
