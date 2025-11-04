using Portal.Core.Entities;
using Portal.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.ViewModels
{
    public class RevistaViewModel
    {
        public RevistaViewModel(Guid id,string titulo, string descricao,
             DateTime publicacao,List<Usuario> autores, Earea area, List<Keywords> keywords, bool isDeleted, byte[]? Capa = null, byte[]? arquivopdf = null)
        {
            this.titulo = titulo;
            this.descricao = descricao;
            this.capa = capa;
            this.publicacao = publicacao;
            //this.arquivopdf = arquivopdf;
            this.autores = autores;
            this.area = area;
            this.keywords = keywords;
            IsDeleted = isDeleted;
        }
        public Guid Id { get;private set; }
        public string titulo { get; private set; }
        public string descricao { get; private set; }
        public byte[]? capa { get; private set; }
        public byte[]? ArquivoPdf { get; set; }
        public DateTime publicacao { get; private set; }
        //public string arquivopdf { get; private set; }
        public List<Usuario> autores { get; private set; }
        public Earea area { get; private set; }
        public List<Keywords> keywords { get; private set; }
        public bool IsDeleted { get; private set; }
    }
}
