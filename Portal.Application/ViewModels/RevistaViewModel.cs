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
             DateTime publicacao,List<UsuarioViewModel> autores, string area, List<KeywordsViewModel> keywords,
             bool isDeleted, string? CapaUrl = null, string? PdfUrl = null)
        {
            Id=id;
            this.titulo = titulo;
            this.descricao = descricao;
            capaUrl = CapaUrl;
            pdfUrl = PdfUrl;
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
        //public byte[]? capa { get; private set; }
        //public byte[]? ArquivoPdf { get; set; }
        public string? capaUrl { get; private set; }
        public string? pdfUrl { get; private set; }
        public DateTime publicacao { get; private set; }
        //public string arquivopdf { get; private set; }
        public List<UsuarioViewModel> autores { get; private set; }
        public string area { get; private set; }
        public List<KeywordsViewModel> keywords { get; private set; }
        public bool IsDeleted { get; private set; }
    }
}
