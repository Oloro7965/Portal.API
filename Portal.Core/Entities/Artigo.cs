using Microsoft.EntityFrameworkCore;
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
        private artigo()
        {

        }
        public artigo(string titulo, string descricao, DateTime publicacao,Earea area,byte[] Arquivopdf,
            List<Keywords>? keywords = null,List<Usuario>? autores = null)
        {
            this.titulo = titulo;
            this.descricao = descricao;
            this.publicacao = publicacao;
            this.arquivopdf = Arquivopdf;
            this.autores = autores ?? new List<Usuario>();
            this.area = area;
            this.keywords = keywords ?? new List<Keywords>();
        }

        public string titulo { get; private set; }
        public string descricao { get; private set; }
        public DateTime publicacao { get; private set; }
        public byte[] arquivopdf { get; private set; }
        public List<Usuario> autores { get; private set; }
        public Earea area { get; private set; }
        public List<Keywords> keywords  { get; private set; }
        public bool IsDeleted { get; private set; }
        public void Delete()
        {
            IsDeleted = true;
        }
        public void Update(string Titulo, string Descricao)
        {
            titulo = Titulo;
            descricao = Descricao;
            
        }
        public void DefinirArquivoPdf(byte[] arquivo)
        {
            arquivopdf = arquivo;
        }
    }
}
