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
        public RevistaViewModel(string titulo, string descricao, string edicao, 
            string capa, DateTime publicacao, string arquivopdf, List<Usuario> autores, Earea area, List<Keywords> keywords, bool isDeleted)
        {
            this.titulo = titulo;
            this.descricao = descricao;
            this.edicao = edicao;
            this.capa = capa;
            this.publicacao = publicacao;
            this.arquivopdf = arquivopdf;
            this.autores = autores;
            this.area = area;
            this.keywords = keywords;
            IsDeleted = isDeleted;
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
    }
}
