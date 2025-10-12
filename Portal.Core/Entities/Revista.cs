using Portal.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Core.Entities
{
    public class Revista:BaseEntity
    {
        public Revista(string titulo, string descricao, string edicao, string capa, DateTime publicacao, Earea area)
        {
            this.titulo = titulo;
            this.descricao = descricao;
            this.edicao = edicao;
            this.capa = capa;
            this.publicacao = publicacao;
            //this.arquivopdf = arquivopdf;
            this.autores = new List<Usuario>();
            this.area = area;
            this.keywords = new List<Keywords>();
        }

        public string titulo { get; private set; }
        public string descricao { get; private set; }
        public string edicao { get; private set; }
        public string capa { get; private set; }
        public DateTime publicacao { get; private set; }
        public string arquivopdf { get; private set; }
        public List<Usuario> autores { get; private set; }
        public Earea area { get; private set; }
        public List<Keywords> keywords { get; private set; }
        public bool IsDeleted { get; private set; }
        public void Delete()
        {
            IsDeleted = true;
        }
        public void Update(string Titulo, string Descricao, string Edicao, string Capa, DateTime Publicacao, string Arquivopdf, List<Usuario> Autores, Earea Area)
        {
            titulo = Titulo;
            descricao = Descricao;
            edicao = Edicao;
            capa = Capa;
            publicacao = Publicacao;
            arquivopdf = Arquivopdf;
            autores = Autores;
            area = Area;
        }   
    }
}
