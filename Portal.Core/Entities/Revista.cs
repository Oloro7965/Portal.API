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
        private Revista() { }
        public Revista(string titulo, string descricao,DateTime publicacao, 
            Earea area,List<Keywords>? keywords = null, byte[]? Capa = null, byte[]? Arquivopdf = null)
        {
            this.titulo = titulo;
            this.descricao = descricao;
            capa = Capa;
            arquivopdf = Arquivopdf;
            this.publicacao = publicacao;
            //this.arquivopdf = arquivopdf;
            this.autores = new List<Usuario>();
            this.area = area;
            this.keywords = keywords ?? new List<Keywords>();
            
        }

        public string titulo { get; private set; }
        public string descricao { get; private set; }
        public byte[] capa { get; private set; }
        public DateTime publicacao { get; private set; }
        public byte[] arquivopdf { get; private set; }
        public List<Usuario> autores { get; private set; }
        public Earea area { get; private set; }
        public List<Keywords> keywords { get; private set; }
        public bool IsDeleted { get; private set; }
        public void Delete()
        {
            IsDeleted = true;
        }
        public void DefinirArquivoPdf(byte[] arquivo)
        {
            arquivopdf = arquivo;
        }
        public void DefinirCapa(byte[] Capa)
        {
            capa=Capa;
        }
        public void Update(string Titulo, string Descricao, string Edicao, DateTime Publicacao, List<Usuario> Autores, Earea Area)
        {
            titulo = Titulo;
            descricao = Descricao;
            publicacao = Publicacao;
            autores = Autores;
            area = Area;
        }   
    }
}
